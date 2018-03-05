using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JobsMe.GatheringCommon.Abstract;

namespace JobsMe.GatheringCommon.Services
{
    public class HttpDataService : IDataService
    {
        public async Task<string> GetDataAsync(string url)
        {
            string res;
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                res = await response.Content.ReadAsStringAsync();
            }

            return res;
        }
    }
}
