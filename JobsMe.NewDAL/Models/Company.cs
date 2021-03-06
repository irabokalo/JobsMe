﻿using System.Collections.Generic;

namespace JobsMe.NewDAL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
