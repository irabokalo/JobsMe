using System.Collections.Generic;

namespace JobsMe.DAL.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public double Experience { get; set; }

        public IList<Offer> Offers { get; set; }
        public IList<Skill> Skills { get; set; }
        public IList<Responsibility> Responsibilities { get; set; }
    }
}
