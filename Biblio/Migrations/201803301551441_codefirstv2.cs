namespace Biblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codefirstv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Type", c => c.String());
        }
    }
}
