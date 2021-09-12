namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartmalo11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Racuns", "Broj", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Racuns", "Broj");
        }
    }
}
