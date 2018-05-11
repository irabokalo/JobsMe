using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using JobsMe.BotApp.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JobsMe.Bot.Commands
{
    public class CompanyCommand:Command
    {
        public override string Name => "Vacancy in company";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            var indexOfCompany = message.Text.IndexOf("company") + 7;
            var seachedCompany = message.Text.Substring(indexOfCompany + 1, message.Text.Length - indexOfCompany - 1);

            Trace.TraceError("Searched Company" + seachedCompany);
            var companiesVacancies = repository.GetVacanciesByCompanyName(seachedCompany);
            client.SendTextMessageAsync(chatId, companiesVacancies.FirstOrDefault()?.VacancyUrl, replyToMessageId: messageId);
        }
    }
}