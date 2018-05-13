using JobsMe.BotApp.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JobsMe.Bot.Commands
{
    public class VacanciesBySkillsCommand : Command
    {
        public override string Name => "vacanciesbyskills";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            Trace.TraceError("Execution of method in VacanciesBySkillsCommand started...");
            try
            {
                var indexOfSkills = message.Text.IndexOf("_", StringComparison.Ordinal);
                var allSkills = message.Text.Substring(indexOfSkills + 1, message.Text.Length - indexOfSkills - 1);
                var skillsStrings = allSkills.Split(',').ToList();
                for (int i = 0; i < skillsStrings.Count; i++)
                {
                    skillsStrings[i] = skillsStrings[i].Trim();
                }
                var vacancies = analyzer.GetVacanciesBySkills(skillsStrings);
                var vacanciesToDisplay = string.Join(Environment.NewLine, vacancies.Select(x => x.VacancyUrl));
            }
            catch (Exception e)
            {
                Trace.TraceError("Exception: " + e.Message);
                throw;
            }
        }
    }
}