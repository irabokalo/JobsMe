using System;

namespace JobsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonData = System.IO.File.ReadAllText(@"rabotaUa.json");
            var config = jsonData.ConvertJsonToClass<RabotaUaConfigEntity>();
            var parser = new RabotaUaParser(config);
            parser.GetJobsForAllPages();

            Console.ReadLine();
        }
    }
}
