namespace Biblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pododaniu1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "confirmedpassword", c => c.String());
            AddColumn("dbo.Movies", "data", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "kto_adminID", c => c.Int());
            AlterColumn("dbo.Admins", "login", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "password", c => c.String(nullable: false));
            CreateIndex("dbo.Movies", "kto_adminID");
            AddForeignKey("dbo.Movies", "kto_adminID", "dbo.Admins", "adminID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "kto_adminID", "dbo.Admins");
            DropIndex("dbo.Movies", new[] { "kto_adminID" });
            AlterColumn("dbo.Admins", "password", c => c.String());
            AlterColumn("dbo.Admins", "login", c => c.String());
            DropColumn("dbo.Movies", "kto_adminID");
            DropColumn("dbo.Movies", "data");
            DropColumn("dbo.Admins", "confirmedpassword");
        }
    }
}
