namespace SocialEyes.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DbUserId", c => c.Int(nullable: false));
        }
    }
}
