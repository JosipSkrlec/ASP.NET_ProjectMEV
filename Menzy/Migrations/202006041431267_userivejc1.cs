namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userivejc1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Subvencija", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Subvencija");
        }
    }
}
