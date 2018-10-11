namespace Biblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pododaniu3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "kto_adminID", "dbo.Admins");
            DropIndex("dbo.Movies", new[] { "kto_adminID" });
            AddColumn("dbo.Movies", "kto", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "kto_adminID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "kto_adminID", c => c.Int());
            DropColumn("dbo.Movies", "kto");
            CreateIndex("dbo.Movies", "kto_adminID");
            AddForeignKey("dbo.Movies", "kto_adminID", "dbo.Admins", "adminID");
        }
    }
}
