using JobsMe.DAL.Models;
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
        }

        public void DeleteStudent(int vacancyId)
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

        public void InsertStudent(Vacancy vacancy)
        {
            context.Vacancies.Add(vacancy);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateStudent(Vacancy vacancy)
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
    }
}
