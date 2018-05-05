using JobsMe.GatheringCommon.Entities;
using JobsMe.GatheringCommon.Extensions;
using System;
using System.Text;

namespace JobsMe.RabotaUaGatherer
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonData = System.IO.File.ReadAllText("rabotaUa.json");
            var config = jsonData.ConvertJsonToClass<RabotaUaConfigEntity>();
            for (int i = 1; i < 4; i++)
            {
                config.Urls.Add(config.BaseSearchUrl.Replace("**", DateTime.Now.AddHours(-24).ToShortDateString())
                                      .Replace("##", i.ToString()).ToString());
            }

            var parser = new RabotaUaParser(config);
            var result = parser.GetRaboutaUaData();

            Console.ReadLine();
        }
    }
}
