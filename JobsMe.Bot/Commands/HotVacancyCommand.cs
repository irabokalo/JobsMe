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
                var companiesVacancies = analyzer.GetHotVacanciesByCompanyName(seachedCompany);
                client.SendTextMessageAsync(chatId,
                    companiesVacancies.Count > 0
                        ? companiesVacancies.FirstOrDefault()?.VacancyUrl
                        : $"No hot vacancies in company: {seachedCompany}",
                    replyToMessageId: messageId);
            }
            catch (Exception e)
            {
                Trace.TraceError("Exception: " + e.Message);
                throw;
            }
        }
    }
}