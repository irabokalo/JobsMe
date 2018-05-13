using HtmlAgilityPack;
using JobsMe.NewDAL;
using JobsMe.NewDAL.Models;
using JobsMe.NewDAL.Repositories.Abstract;
using JobsMe.NewDAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JobsParser
{
    public class RabotaUaParser
    {
        const int PAGES_COUNT = 5;

        private readonly IDataService _dataService = new HttpDataService();
        private RabotaUaConfigEntity _config;
        private IVacancyRepository _repository;

        public RabotaUaParser(RabotaUaConfigEntity config, IDataService dataService)
        {
            _config = config;
            _dataService = dataService;
            _repository = new VacancyRepository();
        }

        public RabotaUaParser(RabotaUaConfigEntity config)
        {
            _config = config;
            _repository = new VacancyRepository();
        }

        public void GetJobsForAllPages()
        {
            var vacancies = new List<VacancyResultItem>();
            var jobIds = new List<int>();
            var allCompanies = new List<string>();

            var jobsCollection = new List<Vacancy>();

            for (int i = 1; i <= PAGES_COUNT; i++)
            {
                var jobs = _dataService.GetAllJobs(_config.SearchRequestUrl, i).Result.Documents
                                       .Where(job => DateTime.Today - job.AddDate.Date == TimeSpan.FromDays(1));
                allCompanies.AddRange(jobs.Select(job => job.CompanyName).Distinct().ToList());
                jobIds.AddRange(jobs.Select(job => job.Id));
                vacancies.AddRange(jobs);
            }

            _repository.BulkSaveInsertCompanies(allCompanies);
            var companies = _repository.GetAllCompaniesByNames(allCompanies).ToList();
            foreach (var vacancy in vacancies)
            {
                var vacancyToInsert = new Vacancy
                {
                    Name = vacancy.Name,
                    RabotaUaId = vacancy.Id,
                    Company = companies.FirstOrDefault(x => x.Name == vacancy.CompanyName),
                    Salary = vacancy.Salary,
                    Hot = vacancy.Hot,
                    CityName = vacancy.CityName,
                    AddDate = vacancy.AddDate,
                    RabotaUaCompanyId = vacancy.NotebookId,
                    VacancyUrl = $"https://rabota.ua/company{vacancy.NotebookId}3184369/vacancy{vacancy.Id}"
                };
                var languageSkills = GetLanguageSkills(vacancy.Languages);
                var description = GetHtmlDescription(vacancy.Id);
                var mainSkills = GetSkillsByDescription(description).Concat(languageSkills);
                vacancyToInsert.Skills = mainSkills.ToList();
                jobsCollection.Add(vacancyToInsert);
            }

            _repository.BulkInsertVacancies(jobsCollection);
            Console.WriteLine("Done");
        }

        public List<Skill> GetSkillsByDescription(string html)
        {
            var skillIds = new List<int>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//li")?.Select(x => x.InnerHtml).ToList();
            if (nodes != null)
            {
                var skillsConcated = string.Join(" ", nodes).ToLower();
                var allSkillsDictionary = GetSkillsDictionary();
                foreach (var skill in allSkillsDictionary)
                {
                    foreach (var skillName in skill.Value)
                    {
                        if (skillsConcated.Contains(skillName.ToLower()))
                        {
                            skillIds.Add(int.Parse(skill.Key));
                            break;
                        }
                    }
                }

                var skills = _repository.GetSkillsByIds(skillIds.Distinct().ToList());
                return skills.ToList();
            }

            return new List<Skill>();
        }

        public string GetHtmlDescription(int id)
        {
            var result = _dataService.GetVacancy(id);
            return result.Result?.Description;
        }

        public Dictionary<string, List<string>> GetSkillsDictionary()
        {
            string jsonData = System.IO.File.ReadAllText("mapping.json");
            return jsonData.ConvertJsonToClass<Dictionary<string, List<string>>>();
        }

        public List<Skill> GetLanguageSkills(List<VacancyLanguage> vacancyLanguages)
        {

            var languageSkills = new List<Skill>();
            foreach (var vacancyLanguage in vacancyLanguages)
            {
                var language = _repository.GetLanguage(vacancyLanguage.LanguageId);
                var languageLevel = _repository.GetLanguageLevel(vacancyLanguage.LevelId);
                if (language != null && languageLevel != null)
                {
                    var skillName = $"{language.En}_{languageLevel.En}";
                    languageSkills.Add(_repository.GetSkillByName(skillName));
                }
            }

            return languageSkills;
        }

        #region Unused but maybe useful
        //public IList<string> GetRaboutaUaData()
        //{
        //    var jobLinks = new List<string>();

        //    foreach (var url in _config.Urls)
        //    {
        //        var result = _dataService.GetDataAsync(url).Result;
        //        jobLinks.AddRange(GetJobLinks(result));
        //    }
        //    GetAllJobs(jobLinks);
        //    return jobLinks;
        //}

        //private List<string> GetJobLinks(string html)
        //{
        //    var jobLinks = new List<string>();

        //    var doc = new HtmlDocument();
        //    doc.LoadHtml(html);
        //    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a[@class='f-visited-enable ga_listing']"))
        //    {
        //        var jobLink = node.GetAttributeValue("href", null);
        //        jobLinks.Add(jobLink);
        //    }

        //    return jobLinks;
        //}

        //private void GetAllJobs(IList<string> jobLinks)
        //{
        //    var jobs = new List<string>();
        //    foreach (var jobLink in jobLinks)
        //    {
        //        var jobHtml = _dataService.GetDataAsync(_config.BaseRabotaUaUrl + jobLink).Result;
        //        jobs.Add(jobHtml);
        //        ParseJob(jobHtml);
        //    }
        //}

        private void ParseJob(string vacancyHtml)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(vacancyHtml);
            var name = doc.DocumentNode.SelectSingleNode("//h1[@class='f-vacname-holder fd-beefy-ronin f-text-black']")?.InnerHtml;
            var salary = doc.DocumentNode.SelectSingleNode("//p[@class='f-salary-holder fd-syoi f-text-black']")
                ?.SelectSingleNode("//span[@class='money']")?.InnerHtml;
            var companyName = doc.DocumentNode.SelectSingleNode("//span[@itemprop='hiringOrganization']")
                ?.SelectSingleNode("//span[@itemprop='name']")?.InnerHtml;

            var mainText = doc.DocumentNode.SelectSingleNode("//div[@class='f-vacancy-description-inner-content']")?.InnerText?.ToLower();
            if (mainText != null)
            {
                var enlishLevel = DetermineEnglishLevel(mainText);
                var experience = DetermineExperience(mainText);
            }
        }

        public string DetermineEnglishLevel(string text)
        {
            var englishIndex = text.IndexOf("english");
            if (englishIndex != -1)
            {
                var okil = GetWordsInRadius(text, 20, englishIndex);
                foreach (var englishLevel in _config.EnglishLevels)
                {
                    if (okil.ToLower().Contains(englishLevel))
                    {
                        return englishLevel;
                    }
                }
            }

            return "Unspecified";
        }

        public string DetermineExperience(string text)
        {
            var index = text.IndexOf("experience");
            if (index != 0)
            {
                var okil = GetWordsInRadius(text, 20, index);
                var result = Regex.Match(okil, @"^\d+").ToString();
                if (!string.IsNullOrEmpty(result))
                {
                    if (okil.Contains("year"))
                    {
                        return result + "years";
                    }
                    else if (okil.Contains("month"))
                    {
                        return result + "months";
                    }
                }
            }

            return "Unspecified";
        }

        public string GetWordsInRadius(string text, int radius, int center)
        {
            var startIndex = (center - radius) >= 0 ? center - radius : 0;
            var textLength = text.Length;
            var endIndex = (center + radius) > textLength ? textLength - 1 : center + radius;
            return text.Substring(startIndex, endIndex - startIndex);
        }

        #endregion
    }
}
