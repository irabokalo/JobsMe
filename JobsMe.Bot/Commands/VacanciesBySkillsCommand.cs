using JobsMe.BotApp.Commands;
using System;
using System.Diagnostics;
using System.Linq;
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

                if (!string.IsNullOrEmpty(allSkills) && message.Text.Contains("_"))
                {
                    var skillsStrings = allSkills.Split(',').ToList();
                    for (int i = 0; i < skillsStrings.Count; i++)
                    {
                        skillsStrings[i] = skillsStrings[i].Trim();
                    }
                    var vacancies = analyzer.GetVacanciesBySkills(skillsStrings);

                    var vacanciesToDisplay =
                        vacancies.Count > 0
                        ? string.Join(Environment.NewLine, vacancies.Select(x => x.VacancyUrl))
                        : "There are no vacancies with such skills";

                    client.SendTextMessageAsync(chatId, vacanciesToDisplay, replyToMessageId: messageId);
                }
                else
                {
                    client.SendTextMessageAsync(chatId,
                        $"Please type your skills, after underscore, seperated by comma, like this vacanciesbyskills_OOP, JAVA ",
                        replyToMessageId: messageId);
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("Exception: " + e.Message);
                throw;
            }
        }
    }
}