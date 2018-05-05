using System;
using System.Collections.Generic;

namespace JobsMe.DAL.Models
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

        public Level Level { get; set; }
        public int? LevelId { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }

        public string Experience { get; set; }

        public string EnglishLevel { get; set; }

        public virtual ICollection<VacancyOffer> VacancyOffers { get; } = new List<VacancyOffer>();
        public virtual ICollection<VacancySkill> VacancySkills { get; } = new List<VacancySkill>();
        public virtual ICollection<VacancyResponsibility> VacancyResponsibilities { get; } = new List<VacancyResponsibility>();
    }
}
