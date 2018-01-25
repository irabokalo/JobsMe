using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobsMe.GatheringCommon.Abstract
{
    public interface IDataService
    {
        Task<string> GetData(string url);
    }
}
