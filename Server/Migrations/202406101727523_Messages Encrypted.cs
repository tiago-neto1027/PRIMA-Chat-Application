namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessagesEncrypted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralChatMessages", "IV", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralChatMessages", "IV");
        }
    }
}
