using HtmlAgilityPack;
using JobsMe.GatheringCommon.Abstract;
using JobsMe.GatheringCommon.Entities;
using JobsMe.GatheringCommon.Services;
using System.Collections.Generic;
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

        public async Task<IList<string>> GetRaboutaUaData()
        {
            var resultList = new List<string>();
            foreach (var url in _config.Urls)
            {
                var result = await _dataService.GetDataAsync(url);
                resultList.Add(result);
                //var allJobLinks = ParseHtml(result); 
            }

            return resultList;
        }

        //private IList<string> ParseHtml(string html)
        //{
        //    var doc = new HtmlDocument();
        //    doc.LoadHtml(html);
        //}
    }
}
