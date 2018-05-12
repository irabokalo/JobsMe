using JobsMe.NewDAL.Models;
using JobsMe.NewDAL.Repositories.Concrete;
using System.Collections.Generic;

namespace DataAnalyzingAlgorithms
{
    public class AnalyzerManager
    {
        private VacancyRepository repository { get; set; } = new VacancyRepository();

        public List<Vacancy> GetVacanciesByCompanyName(string searchedCompany)
        {
            return repository.GetVacanciesByCompanyName(searchedCompany);
        }

        public List<Vacancy> GetHotVacanciesByCompanyName(string searchedCompany)
        {
            return repository.GetHotVacanciesByCompanyName(searchedCompany);
        }


    }
}
