using JobsMe.NewDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsMe.NewDAL
{
    public class JobDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new JobDbContextInitializer());

            base.OnModelCreating(modelBuilder);
        }


        public JobDbContext() : base(@"Server=(localdb)\mssqllocaldb;Database=JobsDbNew;Trusted_Connection=True;")
        {
        }

        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageLevel> LanguageLevels { get; set; }
    }

    public class JobDbContextInitializer : CreateDatabaseIfNotExists<JobDbContext>
    {
        protected override void Seed(JobDbContext context)
        {
            var companies = new Company[]
           {
                 new Company{Name = "ELEKS"},
                 new Company{Name = "SoftServe"},
                 new Company{Name = "EPAM"},
                 new Company{Name = "Sombra"},
                 new Company{Name = "GlobalLogic"},
                 new Company{Name = "DataArt"},
                 new Company{Name = "InterLogic"},
                 new Company{Name = "Lohika"},
           };

            foreach (var company in companies)
            {
                context.Companies.Add(company);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
