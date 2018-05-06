namespace JobsMe.NewDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RabotaUaId = c.Int(),
                        CompanyId = c.Int(nullable: false),
                        Salary = c.Double(nullable: false),
                        CityName = c.String(),
                        AddDate = c.DateTime(nullable: false),
                        Hot = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        KeyWords = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LanguageLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        En = c.String(),
                        Ua = c.String(),
                        Ru = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        En = c.String(),
                        Ua = c.String(),
                        Ru = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillVacancies",
                c => new
                    {
                        Skill_Id = c.Int(nullable: false),
                        Vacancy_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_Id, t.Vacancy_Id })
                .ForeignKey("dbo.Skills", t => t.Skill_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_Id, cascadeDelete: true)
                .Index(t => t.Skill_Id)
                .Index(t => t.Vacancy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillVacancies", "Vacancy_Id", "dbo.Vacancies");
            DropForeignKey("dbo.SkillVacancies", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.Vacancies", "CompanyId", "dbo.Companies");
            DropIndex("dbo.SkillVacancies", new[] { "Vacancy_Id" });
            DropIndex("dbo.SkillVacancies", new[] { "Skill_Id" });
            DropIndex("dbo.Vacancies", new[] { "CompanyId" });
            DropTable("dbo.SkillVacancies");
            DropTable("dbo.Languages");
            DropTable("dbo.LanguageLevels");
            DropTable("dbo.Skills");
            DropTable("dbo.Vacancies");
            DropTable("dbo.Companies");
        }
    }
}
