using System.Collections.Generic;

namespace JobsParser
{
    class JobSearchRequestModel
    {
        public int ParentId { get; set; }
        public List<int> RubricIds { get; set; }
        public int Period { get; set; }
        public int Page { get; set; }
    }
}