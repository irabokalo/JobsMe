using System;
using System.IO;
using JobsMe.GatheringCommon.Entities;
using JobsMe.GatheringCommon.Extensions;

namespace JobsMe.DouGatherer
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonData = System.IO.File.ReadAllText("dou.json");
            var config = jsonData.ConvertJsonToClass<DouConfigEntity>();
            var parser = new DouParser(config);
            var result =  parser.GetDouData().Result;
        }
    }
}
