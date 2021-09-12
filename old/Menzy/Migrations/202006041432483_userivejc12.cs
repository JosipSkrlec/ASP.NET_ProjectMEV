namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userivejc12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Subvencija");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Subvencija", c => c.Double(nullable: false));
        }
    }
}
