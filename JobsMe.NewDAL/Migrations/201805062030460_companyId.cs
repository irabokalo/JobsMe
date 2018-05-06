namespace JobsMe.NewDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacancies", "VacancyUrl", c => c.String());
            AddColumn("dbo.Vacancies", "RabotaUaCompanyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vacancies", "RabotaUaCompanyId");
            DropColumn("dbo.Vacancies", "VacancyUrl");
        }
    }
}
