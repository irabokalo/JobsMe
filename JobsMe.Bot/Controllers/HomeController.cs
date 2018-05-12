using DataAnalyzingAlgorithms;
using JobsMe.NewDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsMe.BotApp.Controllers
{
    public class HomeController : Controller
    {
        public AnalyzerManager analyzer { get; set; } = new AnalyzerManager();

        public string Index()
        {
            return "Hello geeks!";
        }

        public List<Vacancy> GetCompanyVacancies()
        {
            string companyName = "Ciklum";
            var companiesVacancies = analyzer.GetVacanciesByCompanyName(companyName);
            return companiesVacancies;
        }
    }
}