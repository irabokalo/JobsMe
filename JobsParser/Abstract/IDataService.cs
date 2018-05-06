using System.Threading.Tasks;

namespace JobsParser
{
    public interface IDataService
    {
        Task<string> GetDataAsync(string url);
        Task<VacancySearchResponse> GetAllJobs(string url, int page);
    }
}
