namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutContentShort", c => c.String());
            AddColumn("dbo.Abouts", "AboutContentShortImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AboutContentShortImage");
            DropColumn("dbo.Abouts", "AboutContentShort");
        }
    }
}
