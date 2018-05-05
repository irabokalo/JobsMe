using JobsMe.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsMe.DAL
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext(DbContextOptions<JobsDbContext> options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
        }


        DbSet<User> Users { get; set; }
        DbSet<Vacancy> Vacancies { get; set; }
        DbSet<Skill> Skills { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Offer> Offers { get; set; }
        DbSet<Responsibility> Responsibilities { get; set; }
        DbSet<Level> Levels { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
