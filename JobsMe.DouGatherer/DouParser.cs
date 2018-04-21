using System;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JobsMe.GatheringCommon.Abstract;
using JobsMe.GatheringCommon.Entities;
using JobsMe.GatheringCommon.Services;

namespace JobsMe.DouGatherer
{
    public class DouParser
    {
        private readonly  IDataService _dataService = new HttpDataService();
        private DouConfigEntity _config;

        public DouParser(DouConfigEntity config, IDataService dataService)
        {
            _config = config;
            _dataService = dataService;
        }

        public DouParser(DouConfigEntity config)
        {
            _config = config;
        }

        public async Task<string> GetDouData()
        {
            foreach (var url in _config.Urls)
            {
                var html = await _dataService.GetDataAsync(url);
                var parsedData = await ParseData(html);
            }



            return String.Empty;
        }

        public async Task<string> ParseData(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.DocumentNode;
            var vacancies = nodes.SelectNodes(string.Format("//*[contains(@class,'{0}')]", "vt"));
            var vacanciesUrl = vacancies.Select(x=>x.Attributes["href"].Value);

            foreach (var singleUrl in vacanciesUrl)
            {
                var infoAboutVacancy = _dataService.GetDataAsync(singleUrl);

            }
            return string.Empty;
        }


        private async Task<string> ParseVacancy(string infoAboutVacancy)
        {
            return string.Empty;
        }
        
    }
}
