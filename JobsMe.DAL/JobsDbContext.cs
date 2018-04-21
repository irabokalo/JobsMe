using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace JobsMe.DAL
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext() : base("JobsDb")
        {

        }
    }
}
