namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGeneralChatMessages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralChatMessages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        SenderID = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneralChatMessages");
        }
    }
}
