﻿using JobsMe.DAL.Models;
using JobsMe.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobsMe.DAL.Repositories.Concrete
{
    public class VacancyRepository : IVacancyRepository
    {
        private JobsDbContext context;

        public VacancyRepository()
        {
            context = new JobsDbContext();
            DbInitializer.Initialize(context);
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

    }
}