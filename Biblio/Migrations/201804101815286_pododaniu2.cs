namespace Biblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pododaniu2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "TypeString", c => c.String());
            AlterColumn("dbo.Admins", "password", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Movies", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "password", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "TypeString");
        }
    }
}
