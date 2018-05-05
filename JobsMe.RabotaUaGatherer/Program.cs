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
            var parser = new RabotaUaParser(config);
            parser.GetJobsForAllPages();

            Console.ReadLine();
        }
    }
}
