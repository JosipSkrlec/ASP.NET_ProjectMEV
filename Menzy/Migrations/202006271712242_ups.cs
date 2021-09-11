namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ups : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Foods", "Kalorije");
            DropColumn("dbo.Foods", "Masti");
            DropColumn("dbo.Foods", "UHidrati");
            DropColumn("dbo.Foods", "Sol");
            DropColumn("dbo.Foods", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "Sol", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "UHidrati", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "Masti", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "Kalorije", c => c.Int(nullable: false));
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
