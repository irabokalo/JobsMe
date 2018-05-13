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
    public class RandomCommand : Command
    {
        public override string Name { get; } = "randomvacancy";
        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            Trace.TraceInformation("Command random vacancy execution started...");
            try
            {

                var randomVacancy = analyzer.GetRandomVacancy();
                client.SendTextMessageAsync(chatId,
               randomVacancy.VacancyUrl,
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