using System.Collections.Generic;

namespace JobsMe.GatheringCommon.Entities
{
    public class RabotaUaConfigEntity
    {
        public string BaseUrl { get; set; }
        public List<string> Urls { get; set; } = new List<string>();
    }
}
