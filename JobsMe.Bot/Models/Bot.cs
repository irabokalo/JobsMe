﻿using JobsMe.Bot.Commands;
using JobsMe.BotApp.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace JobsMe.BotApp.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());
            commandsList.Add(new HotVacancyCommand());
            commandsList.Add(new CompanyCommand());
            commandsList.Add(new VacanciesBySkillsCommand());
            commandsList.Add(new RandomCommand());
            commandsList.Add(new RecommendedSkillsCommand());
            commandsList.Add(new ChancesCommand());
            //TODO: Add more commands

            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}