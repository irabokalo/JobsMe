using Telegram.Bot.Types;
using Telegram.Bot;
using JobsMe.BotApp.Models;

namespace JobsMe.BotApp.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(AppSettings.Name);
        }

    }
}