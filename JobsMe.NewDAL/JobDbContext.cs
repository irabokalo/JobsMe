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

        public JobDbContext() : base(@"Server=TOSHIBA;Database=JobsDbNew;Trusted_Connection=True;")
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
            var languages = new Language[]
            {
                new Language { Id=1, En="English", Ru="Английский", Ua="Англійська" },
                new Language { Id=2, En="German", Ru="Немецкий", Ua="Німецька" },
                new Language { Id=3, En="French", Ru="Французский", Ua="Французька" },
                new Language { Id=4, En="Spanish", Ru="Испанский", Ua="Іспанська" },
                new Language { Id=5, En="Italian", Ru="Итальянский", Ua="Італійська" }
            };
            foreach (var language in languages)
            {
                context.Languages.Add(language);
            }

            var languageLevels = new LanguageLevel[]
            {
                new LanguageLevel {Id =1, En="elementary", Ua="базовий", Ru="базовый"},
                new LanguageLevel {Id =2, En="lower intermediate", Ua="нижче середнього", Ru="ниже среднего"},
                new LanguageLevel {Id =3, En="intermediate", Ua="середній", Ru="средний"},
                new LanguageLevel {Id =6, En="upper intermediate", Ua="вище середнього", Ru="выше среднего"},
                new LanguageLevel {Id =4, En="advanced", Ua="поглиблений", Ru="продвинутый"},
                new LanguageLevel {Id =5, En="fluent", Ua="вільно", Ru="свободно"},
                new LanguageLevel {Id =7, En="native", Ua="рідна", Ru="родной"}
            };
            foreach (var languageLevel in languageLevels)
            {
                context.LanguageLevels.Add(languageLevel);
            }

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
