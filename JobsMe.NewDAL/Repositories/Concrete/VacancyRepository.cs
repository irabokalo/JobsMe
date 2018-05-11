using JobsMe.NewDAL.Models;
using JobsMe.NewDAL.Repositories.Abstract;
using JobsMe.NewDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JobsMe.NewDAL.Repositories.Concrete
{
    public class VacancyRepository : IVacancyRepository
    {
        private JobDbContext context;

        public VacancyRepository()
        {
            context = new JobDbContext();
        }

        public void DeleteVacancy(int vacancyId)
        {
            Vacancy vacancy = context.Vacancies.Find(vacancyId);
            context.Vacancies.Remove(vacancy);
        }

        public IEnumerable<Vacancy> GetVacancies()
        {
            return context.Vacancies.ToList();
        }

        public Vacancy GetVacancy(int vacancyId)
        {
            return context.Vacancies.Find(vacancyId);
        }

        public void InsertVacancy(Vacancy vacancy)
        {
            context.Vacancies.Add(vacancy);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateVacancy(Vacancy vacancy)
        {
            context.Entry(vacancy).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BulkSaveInsertCompanies(IList<string> companyNames)
        {
            var allCompanies = context.Companies.Select(x => x.Name.ToLower()).ToList();
            var companiesToInsert = companyNames.Where(x => !allCompanies.Contains(x.ToLower()))
                .Select(y => new Company { Name = y });
            context.Companies.AddRange(companiesToInsert);

            context.SaveChanges();
        }

        public void BulkInsertVacancies(IEnumerable<Vacancy> vacancies)
        {
            context.Vacancies.AddRange(vacancies);
            context.SaveChanges();
        }

        public IEnumerable<Company> GetAllCompaniesByNames(IEnumerable<string> companyNames)
        {
            return context.Companies.Where(x => companyNames.ToList().Contains(x.Name));
        }

        public Language GetLanguage(int languageId)
        {
            return context.Languages.FirstOrDefault(x => x.Id == languageId);
        }

        public LanguageLevel GetLanguageLevel(int levelId)
        {
            return context.LanguageLevels.FirstOrDefault(x => x.Id == levelId);
        }

        public List<Vacancy> GetVacanciesByCompanyName(string companyName)
        {
            int companyId = context.Companies.FirstOrDefault(x => x.Name.Contains(companyName)).Id;

            var vacancies = context.Vacancies.Where(x => x.CompanyId == companyId).Take(5).ToList();

            return vacancies;
        }
        public List<Vacancy> GetHotVacanciesByCompanyName(string companyName)
        {
            int companyId = context.Companies.FirstOrDefault(x => x.Name.Contains(companyName)).Id;

            var vacancies = context.Vacancies.Where(x => x.CompanyId == companyId && x.Hot).Take(5).ToList();

            return vacancies;
        }

        public Skill GetSkillByName(string name)
        {
            return context.Skills.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public IList<Skill> GetSkillsByIds(IList<int> ids)
        {
            return context.Skills.Where(skill => ids.Contains(skill.Id)).ToList();
        }
    }
}
