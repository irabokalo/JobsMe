using JobsMe.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsMe.DAL
{
    public class JobsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=JobsDb;Trusted_Connection=True;");
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
