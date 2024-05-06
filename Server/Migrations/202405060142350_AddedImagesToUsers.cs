namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagesToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProfilePic", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ProfilePic");
        }
    }
}
