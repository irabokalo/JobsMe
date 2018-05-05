using JobsMe.DAL.Models;
using System;
using System.Collections.Generic;

namespace JobsMe.DAL.Repositories.Abstract
{
    public interface IVacancyRepository: IDisposable
    {
        IEnumerable<Vacancy> GetVacancies();
        Vacancy GetVacancy(int vacancyId);
        void InsertStudent(Vacancy vacancy);
        void DeleteStudent(int vacancyId);
        void UpdateStudent(Vacancy vacancy);
        void Save();
    }
}
