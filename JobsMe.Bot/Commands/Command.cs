using Telegram.Bot.Types;
using Telegram.Bot;
using JobsMe.BotApp.Models;
using JobsMe.NewDAL.Repositories.Concrete;

namespace JobsMe.BotApp.Commands
{
    public abstract class Command
    {
        public VacancyRepository repository { get; set; } = new VacancyRepository();
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }

    }
}