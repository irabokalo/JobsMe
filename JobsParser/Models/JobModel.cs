using System;
using System.Collections.Generic;
using System.Text;

namespace JobsParser
{
    public class VacancySearchResponse
    {
        public List<VacancyResultItem> Documents { get; set; }
    }

    public class VacancyResultItem
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public DateTime AddDate { get; set; }
        public bool Hot { get; set; }
        public string CompanyName { get; set; }
        public double Salary { get; set; }
        public int ProfLevelId { get; set; }
        public int NotebookId { get; set; }
    }
}