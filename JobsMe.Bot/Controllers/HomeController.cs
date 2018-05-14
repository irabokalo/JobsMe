using DataAnalyzingAlgorithms;
using JobsMe.Bot.Commands;
using JobsMe.NewDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

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
            var companiesVacancies = analyzer.GetVacanciesByCompanyName(companyName).ToList();
            return companiesVacancies;
        }

        public int TestBasicApriory()
        {
            return 0;
        }

        //public class Message
        //{
        //    public string Text { get; set; }
        //    public Message(string t)
        //    {
        //        Text = t;
        //    }
        //}

        public string GetVacanciesBySkills()
        {
            //var message = new Message("C#, OOD");
            //var indexOfSkills = message.Text.IndexOf("_", StringComparison.Ordinal);
            //var allSkills = message.Text.Substring(indexOfSkills + 1, message.Text.Length - indexOfSkills - 1);
            //var skillsStrings = allSkills.Split(',').ToList();
            //for(int i=0; i<skillsStrings.Count; i++)
            //{
            //    skillsStrings[i] = skillsStrings[i].Trim();
            //}
            //var vacancies = analyzer.GetVacanciesBySkills(skillsStrings);
            //var vacanciesToDisplay = string.Join(Environment.NewLine, vacancies.Select(x => x.VacancyUrl));
            //return vacanciesToDisplay;

            var command = new VacanciesBySkillsCommand();
            var msg = new Message()
            {
                Text = "vacanciesbyskills_.net, scrum",
                MessageId=1,
                Chat = new Chat()
            };
            var client = new TelegramBotClient("484073226:AAHeu6pL7cR9138EO4rOmNA6Qj1xoIEkp38");
            command.Execute(msg, client);
            return null;
        }
    }
}