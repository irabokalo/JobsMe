﻿using JobsMe.NewDAL.Models;
using System;
using System.Collections.Generic;

namespace JobsMe.NewDAL.Repositories.Abstract
{
    public interface IVacancyRepository: IDisposable
    {
        IEnumerable<Vacancy> GetVacancies();
        Vacancy GetVacancy(int vacancyId);
        void InsertVacancy(Vacancy vacancy);
        void BulkInsertVacancies(IEnumerable<Vacancy> vacancies);
        void DeleteVacancy(int vacancyId);
        void UpdateVacancy(Vacancy vacancy);
        Vacancy GetRandomVacancy();
        void Save();
        void BulkSaveInsertCompanies(IList<string> companyNames);
        IEnumerable<Company> GetAllCompaniesByNames(IEnumerable<string> companyNames);
        Language GetLanguage(int languageId);
        LanguageLevel GetLanguageLevel(int levelId);
        Skill GetSkillByName(string name);
        IList<Skill> GetSkillsByIds(IList<int> ids);
        IList<Skill> GetSkillsByNames(IList<string> names);
        IList<Vacancy> GetVacanciesByCompanyName(string companyName);
        IList<Vacancy> GetHotVacanciesByCompanyName(string companyName);
        IList<Vacancy> GetActualVacancies(DateTime date);
    }
}
