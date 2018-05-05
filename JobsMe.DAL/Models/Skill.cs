using System.Collections.Generic;

namespace JobsMe.DAL.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string KeyWords { get; set; }

        public virtual ICollection<VacancySkill> VacancySkills { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
