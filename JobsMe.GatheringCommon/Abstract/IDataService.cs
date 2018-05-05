using JobsMe.RabotaUaGatherer.Models;
using System.Threading.Tasks;

namespace JobsMe.GatheringCommon.Abstract
{
    public interface IDataService
    {
        Task<string> GetDataAsync(string url);
        Task<VacancySearchResponse> GetAllJobs(string url, int page);
    }
}
