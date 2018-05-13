using DataAnalyzingAlgorithms.Models;
using JobsMe.NewDAL.Models;
using JobsMe.NewDAL.Repositories.Abstract;
using JobsMe.NewDAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzingAlgorithms
{
    public class AnalyzerManager
    {
        private IVacancyRepository repository { get; set; } = new VacancyRepository();

        public IList<Vacancy> GetVacanciesByCompanyName(string searchedCompany)
        {
            return repository.GetVacanciesByCompanyName(searchedCompany);
        }

        public IList<Vacancy> GetHotVacanciesByCompanyName(string searchedCompany)
        {
            return repository.GetHotVacanciesByCompanyName(searchedCompany);
        }

        public Vacancy GetRandomVacancy()
        {
            return repository.GetRandomVacancy();
        }

        public IList<Vacancy> GetVacanciesBySkills(List<string> skillsNames)
        {
            var skills = repository.GetSkillsByNames(skillsNames);
            var freshVacancies = repository.GetActualVacancies(DateTime.Today.AddDays(-3));
            var analysisModels = new List<VacancySkillsAnalysisModel>();

            foreach (var vacancy in freshVacancies)
            {
                var commonSkills = vacancy.Skills.Intersect(skills);
                //TODO - Add threshold here
                analysisModels.Add(new VacancySkillsAnalysisModel
                {
                    Vacancy = vacancy,
                    Probability = vacancy.Skills.Count != 0
                        ? (double)commonSkills.Count() / (double)vacancy.Skills.Count * 100
                        : 0
                });
            }

            var result = analysisModels.OrderByDescending(x => x.Probability).Where(z=>z.Probability>0)
                .Take(5).Select(y => y.Vacancy).ToList();
            return result;
        }

    }
}
