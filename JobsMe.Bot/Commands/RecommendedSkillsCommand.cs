using JobsMe.BotApp.Commands;
using System;
using System.Diagnostics;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace JobsMe.Bot.Commands
{
    public class RecommendedSkillsCommand : Command
    {
        public override string Name { get; } = "recommendedskills";
        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            Trace.TraceInformation("Command recommendedskills execution started...");
            try
            {
                string recommendedSkills = "";
                client.SendTextMessageAsync(chatId, recommendedSkills, replyToMessageId: messageId);
            }
            catch (Exception e)
            {
                Trace.TraceError("Exception: " + e.Message);
                throw;
            }
        }
    }
}