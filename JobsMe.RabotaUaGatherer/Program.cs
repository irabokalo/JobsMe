using JobsMe.DAL;
using JobsMe.DAL.Models;
using JobsMe.GatheringCommon.Entities;
using JobsMe.GatheringCommon.Extensions;
using System;

namespace JobsMe.RabotaUaGatherer
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonData = System.IO.File.ReadAllText("./rabotaUa.json");
            var config = jsonData.ConvertJsonToClass<RabotaUaConfigEntity>();
            for (int i = 1; i < 2; i++)
            {
                config.Urls.Add(config.BaseSearchUrl.Replace("**", DateTime.Now.AddHours(-24).ToShortDateString())
                                      .Replace("##", i.ToString()).ToString());
            }

            var parser = new RabotaUaParser(config);
            var result = parser.GetRaboutaUaData();


            //using (var db = new JobsDbContext())
            //{
            //    DbInitializer.Initialize(db);
            //    foreach (var a in db.Levels)
            //    {
            //        Console.WriteLine(" - {0}", a.Name);
            //    }
            //}

            Console.ReadLine();
        }
    }
}
