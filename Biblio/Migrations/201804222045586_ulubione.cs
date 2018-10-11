namespace Biblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ulubione : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        favID = c.Int(nullable: false, identity: true),
                        who = c.Int(nullable: false),
                        which = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.favID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Favourites");
        }
    }
}
