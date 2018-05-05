using System.Collections.Generic;

namespace JobsMe.GatheringCommon.Entities
{
    public class RabotaUaConfigEntity
    {
        public string SearchRequestUrl { get; set; }
        public string BaseRabotaUaUrl { get; set; }
        public List<string> Urls { get; set; } = new List<string>();
        public List<string> RequirementsKeysWords { get; set; } = new List<string>();
        public List<string> ExperienceKeyWords { get; set; } = new List<string>();
        public List<string> OffersKeyWords { get; set; } = new List<string>();
        public List<string> EnglishLevels { get; set; } = new List<string>();
    }
}
