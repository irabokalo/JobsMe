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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //VacancyOffer
            modelBuilder.Entity<VacancyOffer>()
           .HasKey(t => new { t.VacancyId, t.OfferId });

            modelBuilder.Entity<VacancyOffer>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(p => p.VacancyOffers)
                .HasForeignKey(pt => pt.VacancyId);

            modelBuilder.Entity<VacancyOffer>()
                .HasOne(pt => pt.Offer)
                .WithMany(t => t.VacancyOffers)
                .HasForeignKey(pt => pt.OfferId);

            //VacancySkill
            modelBuilder.Entity<VacancySkill>()
         .HasKey(t => new { t.VacancyId, t.SkillId });

            modelBuilder.Entity<VacancySkill>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(p => p.VacancySkills)
                .HasForeignKey(pt => pt.VacancyId);

            modelBuilder.Entity<VacancySkill>()
                .HasOne(pt => pt.Skill)
                .WithMany(t => t.VacancySkills)
                .HasForeignKey(pt => pt.SkillId);


            //VacancyResponsibilities
            modelBuilder.Entity<VacancyResponsibility>()
         .HasKey(t => new { t.VacancyId, t.ResponsibilityId });

            modelBuilder.Entity<VacancyResponsibility>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(p => p.VacancyResponsibilities)
                .HasForeignKey(pt => pt.VacancyId);

            modelBuilder.Entity<VacancyResponsibility>()
                .HasOne(pt => pt.Responsibility)
                .WithMany(t => t.VacancyResponsibilities)
                .HasForeignKey(pt => pt.ResponsibilityId);

            //UserSkills
            modelBuilder.Entity<UserSkill>()
         .HasKey(t => new { t.UserId, t.SkillId });

            modelBuilder.Entity<UserSkill>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserSkills)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserSkill>()
                .HasOne(pt => pt.Skill)
                .WithMany(t => t.UserSkills)
                .HasForeignKey(pt => pt.SkillId);
        }
    }
}
