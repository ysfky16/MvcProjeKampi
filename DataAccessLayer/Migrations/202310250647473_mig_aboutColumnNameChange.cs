namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_aboutColumnNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutImage1", c => c.String(maxLength: 100));
            AddColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
            DropColumn("dbo.Abouts", "Aboutİmage1");
            DropColumn("dbo.Abouts", "Aboutİmage2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "Aboutİmage2", c => c.String(maxLength: 100));
            AddColumn("dbo.Abouts", "Aboutİmage1", c => c.String(maxLength: 100));
            DropColumn("dbo.Abouts", "AboutImage2");
            DropColumn("dbo.Abouts", "AboutImage1");
        }
    }
}
