namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeanjesub : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "EmailStud", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "JMBAG", c => c.String(maxLength: 10));
            DropColumn("dbo.Customers", "Subvencija");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Subvencija", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "JMBAG", c => c.String());
            AlterColumn("dbo.Customers", "EmailStud", c => c.String());
        }
    }
}
