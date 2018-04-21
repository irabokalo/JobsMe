using System.Threading.Tasks;
using JobsMe.GatheringCommon.Abstract;
using RestSharp;

namespace JobsMe.GatheringCommon.Services
{
    public class HttpDataService : IDataService
    {
        public async Task<string> GetDataAsync(string url)
        {
            var client = new RestClient(url)
            {
                FollowRedirects = true
            };

            var request = new RestRequest(Method.GET);
            request.AddHeader("User-Agent", @"Mozilla / 5.0(Windows NT 6.3; WOW64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 54.0.2840.99 Safari / 537.3");
            var restResponse = await client.ExecuteTaskAsync(request);
            return restResponse.Content;
        }
    }
}
