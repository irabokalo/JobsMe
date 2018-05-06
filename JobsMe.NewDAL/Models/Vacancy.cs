using System;
using System.Collections.Generic;

namespace JobsMe.NewDAL.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RabotaUaId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public double Salary { get; set; }
        public string CityName { get; set; }
        public DateTime AddDate { get; set; }
        public bool Hot { get; set; }
        public string VacancyUrl { get; set; }
        public int RabotaUaCompanyId { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
