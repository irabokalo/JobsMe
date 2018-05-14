using JobsMe.BotApp.Commands;
using System;
using System.Diagnostics;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JobsMe.Bot.Commands
{
    public class ChancesCommand : Command
    {
        public override string Name { get; } = "chances";
        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            Trace.TraceInformation("Command chances execution started...");
            try
            {
                string chance = "You chance to find job with this skill - ";
                client.SendTextMessageAsync(chatId, chance,
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