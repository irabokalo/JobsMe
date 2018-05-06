using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsMe.BotApp.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://telegrambotapp.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "JobAdviser_bot";

        public static string Key { get; set; } = "484073226:AAHeu6pL7cR9138EO4rOmNA6Qj1xoIEkp38";

    }
}