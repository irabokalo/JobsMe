using HtmlAgilityPack;
using JobsMe.GatheringCommon.Abstract;
using JobsMe.GatheringCommon.Entities;
using JobsMe.GatheringCommon.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsMe.RabotaUaGatherer
{
    public class RabotaUaParser
    {
        private readonly IDataService _dataService = new HttpDataService();
        private RabotaUaConfigEntity _config;

        public RabotaUaParser(RabotaUaConfigEntity config, IDataService dataService)
        {
            _config = config;
            _dataService = dataService;
        }

        public RabotaUaParser(RabotaUaConfigEntity config)
        {
            _config = config;
        }

        public IList<string> GetRaboutaUaData()
        { 
            var jobLinks = new List<string>();

            foreach (var url in _config.Urls)
            {
                var result =  _dataService.GetDataAsync(url).Result;
                jobLinks.AddRange(GetJobLinks(result)); 
            }
            GetAllJobs(jobLinks);
            return jobLinks;
        }

        private List<string> GetJobLinks(string html)
        {
            var jobLinks = new List<string>();

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a[@class='f-visited-enable ga_listing']"))
            {
                var jobLink = node.GetAttributeValue("href", null);
                jobLinks.Add(jobLink);
            }

            return jobLinks;
        }

        private void GetAllJobs(IList<string> jobLinks)
        {
            var jobs = new List<string>();
            foreach(var jobLink in jobLinks)
            {
                var jobHtml = _dataService.GetDataAsync(_config.BaseRabotaUaUrl + jobLink).Result;
                jobs.Add(jobHtml);
            }
        }

        private void ParseJob(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var a = doc.DocumentNode.SelectNodes("//p").Where(x => _config.RequirementsKeysWords.Any(x.InnerText.ToLower().Contains));
        }
    }
}
