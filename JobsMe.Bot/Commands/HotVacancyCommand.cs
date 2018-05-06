using JobsMe.BotApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JobsMe.Bot.Commands
{
    public class HotVacancyCommand:Command
    {
        public override string Name => "Hot Vacancy in company";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            var indexOfCompany = message.Text.IndexOf("company") + 7;
            var seachedCompany = message.Text.Substring(indexOfCompany, message.Text.Length - indexOfCompany);
       
           

            client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }
    }
}