namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterShih : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Racuns", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Racuns", new[] { "Customer_Id" });
            AddColumn("dbo.AspNetUsers", "Ime", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Prezime", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "KojiFaks", c => c.String());
            AddColumn("dbo.AspNetUsers", "JMBAG", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.AspNetUsers", "Redovni", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Racuns", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Racuns", "Customer_Id");
            AddForeignKey("dbo.Racuns", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Racuns", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Racuns", new[] { "Customer_Id" });
            AlterColumn("dbo.Racuns", "Customer_Id", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Redovni");
            DropColumn("dbo.AspNetUsers", "JMBAG");
            DropColumn("dbo.AspNetUsers", "KojiFaks");
            DropColumn("dbo.AspNetUsers", "Prezime");
            DropColumn("dbo.AspNetUsers", "Ime");
            CreateIndex("dbo.Racuns", "Customer_Id");
            AddForeignKey("dbo.Racuns", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
