using System.Threading.Tasks;
using JobsMe.GatheringCommon.Abstract;
using JobsMe.GatheringCommon.Entities;
using JobsMe.GatheringCommon.Services;

namespace JobsMe.DouGatherer
{
    public class DouParser
    {
        private readonly  IDataService _dataService = new HttpDataService();
        private ConfigEntity _config;

        public DouParser(ConfigEntity config, IDataService dataService)
        {
            _config = config;
            _dataService = dataService;
        }

        public DouParser(ConfigEntity config)
        {
            _config = config;
        }

        public async Task<string> GetDouData()
        {
            var result = await _dataService.GetDataAsync(_config.BaseUrl);



            return result;
        }

    }
}
