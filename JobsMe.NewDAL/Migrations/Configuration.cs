using JobsMe.NewDAL.Models;

namespace JobsMe.NewDAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JobsMe.NewDAL.JobDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "JobsMe.NewDAL.JobDbContext";
        }

        protected override void Seed(JobsMe.NewDAL.JobDbContext context)
        {
           
                var languages = new Language[]
                {
                new Language {Id = 1, En = "English", Ru = "����������", Ua = "���������"},
                new Language {Id = 2, En = "German", Ru = "��������", Ua = "ͳ������"},
                new Language {Id = 3, En = "French", Ru = "�����������", Ua = "����������"},
                new Language {Id = 4, En = "Spanish", Ru = "���������", Ua = "���������"},
                new Language {Id = 5, En = "Italian", Ru = "�����������", Ua = "���������"}
                };
                foreach (var language in languages)
                {
                    context.Languages.Add(language);
                }

                var languageLevels = new LanguageLevel[]
                {
                new LanguageLevel {Id = 1, En = "elementary", Ua = "�������", Ru = "�������"},
                new LanguageLevel {Id = 2, En = "lower intermediate", Ua = "����� ����������", Ru = "���� ��������"},
                new LanguageLevel {Id = 3, En = "intermediate", Ua = "�������", Ru = "�������"},
                new LanguageLevel {Id = 6, En = "upper intermediate", Ua = "���� ����������", Ru = "���� ��������"},
                new LanguageLevel {Id = 4, En = "advanced", Ua = "�����������", Ru = "�����������"},
                new LanguageLevel {Id = 5, En = "fluent", Ua = "�����", Ru = "��������"},
                new LanguageLevel {Id = 7, En = "native", Ua = "����", Ru = "������"}
                };
                foreach (var languageLevel in languageLevels)
                {
                    context.LanguageLevels.Add(languageLevel);
                }

                var companies = new Company[]
                {
                new Company {Name = "ELEKS"},
                new Company {Name = "SoftServe"},
                new Company {Name = "EPAM"},
                new Company {Name = "Sombra"},
                new Company {Name = "GlobalLogic"},
                new Company {Name = "DataArt"},
                new Company {Name = "InterLogic"},
                new Company {Name = "Lohika"},
                };

                foreach (var company in companies)
                {
                    context.Companies.Add(company);
                }

                context.Skills.Add(new Skill
                {
                    Name = "C#"
                });
                context.Skills.Add(new Skill
                {
                    Name = "ASP.NET"
                });
                context.Skills.Add(new Skill
                {
                    Name = "OOP"
                });
                context.SaveChanges();
        }
    }
}
