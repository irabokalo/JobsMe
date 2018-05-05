using System.Collections.Generic;

namespace JobsMe.DAL.Models
{
    public class Responsibility
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VacancyResponsibility> VacancyResponsibilities { get; set; }
    }
}
