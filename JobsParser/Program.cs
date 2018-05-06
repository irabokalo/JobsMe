using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsParser
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
