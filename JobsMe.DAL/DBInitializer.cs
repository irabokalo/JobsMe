using JobsMe.DAL.Models;
using System.Linq;

namespace JobsMe.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(JobsDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            var levels = new Level[]
            {
                 new Level{Name = "Junior"},
                 new Level{Name = "Middle"},
                 new Level{Name = "Senior"},
                 new Level{Name = "Tech Lead"},
                 new Level{Name = "Solution Architect"}
            };
            foreach (var level in levels)
            {
                context.Levels.Add(level);
            }
            context.SaveChanges();

            var categories = new Category[]
           {
                 new Category{Name = "C#"},
                 new Category{Name = "Java"},
                 new Category{Name = "Database"}
           };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

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

        }
    }
}
