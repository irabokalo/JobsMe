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
            var indexOfCompany = message.Text.IndexOf("company") + 7;
            var searchedCompany = message.Text.Substring(indexOfCompany+1, message.Text.Length - indexOfCompany-1);

            Trace.TraceError("Searched Company" + searchedCompany);
            var companiesVacancies = analyzer.GetHotVacanciesByCompanyName(searchedCompany);
            client.SendTextMessageAsync(chatId, companiesVacancies.FirstOrDefault()?.VacancyUrl, replyToMessageId: messageId);
        }
    }
}