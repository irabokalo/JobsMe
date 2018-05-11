using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace JobsParser
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

        public async Task<VacancySearchResponse> GetAllJobs(string url, int page)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new JobSearchRequestModel{
                ParentId = 1,
                RubricIds = new List<int> {    11,6,9,8 },
                Period = 2,
                Page = page
            });
            var response = await client.ExecuteTaskAsync(request);
            var results = JsonConvert.DeserializeObject<VacancySearchResponse>(response.Content);
            return results;
        }

        public async Task<VacancyResultItem> GetVacancy(int id)
        {
            var client = new RestClient("https://api.rabota.ua/vacancy?id="+id);
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;          
            var response = await client.ExecuteTaskAsync(request);
            var results = JsonConvert.DeserializeObject<VacancyResultItem>(response.Content);
            return results;
        }
    }
}
