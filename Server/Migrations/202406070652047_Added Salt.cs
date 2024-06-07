namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSalt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Salt", c => c.String());
            DropColumn("dbo.Users", "ProfilePic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ProfilePic", c => c.Binary());
            DropColumn("dbo.Users", "Salt");
        }
    }
}
