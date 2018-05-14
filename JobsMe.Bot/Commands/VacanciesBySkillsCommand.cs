using JobsMe.BotApp.Commands;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

                    string vacanciesToDisplay;
                    if (vacancies.Count == 0)
                    {
                        vacanciesToDisplay = "There are no vacancies with such skills";
                    }
                    else
                    {
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < vacancies.Count; i++)
                        {
                            builder.Append($"Vacancy #{i + 1} - {vacancies[i].Vacancy.VacancyUrl}" + Environment.NewLine);
                            builder.Append($"Chance = {vacancies[i].Probability}%" + Environment.NewLine);
                        }

                        vacanciesToDisplay = builder.ToString();
                    }

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