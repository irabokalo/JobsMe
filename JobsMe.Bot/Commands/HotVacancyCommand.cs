using JobsMe.BotApp.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JobsMe.Bot.Commands
{
    public class HotVacancyCommand : Command
    {
        public override string Name => "hotvacancyincompany";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            Trace.TraceInformation("Method execution started...");
            try
            {
                var indexOfCompany = message.Text.IndexOf("_", StringComparison.Ordinal);
                var seachedCompany = message.Text.Substring(indexOfCompany + 1, message.Text.Length - indexOfCompany - 1);

                Trace.TraceInformation("Searched Company: " + seachedCompany);
                if (!seachedCompany.IsEmpty() && message.Text.Contains("_"))
                {
                    var companiesVacancies = analyzer.GetHotVacanciesByCompanyName(seachedCompany);
                    client.SendTextMessageAsync(chatId,
                        companiesVacancies.Count > 0
                            ? companiesVacancies.FirstOrDefault()?.VacancyUrl
                            : $"No hot vacancies in company: {seachedCompany}",
                        replyToMessageId: messageId);
                }
                else
                {
                    client.SendTextMessageAsync(chatId,
               $"Please type a company name, after underscore, like this hotvacancyincompany_Eleks ",
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