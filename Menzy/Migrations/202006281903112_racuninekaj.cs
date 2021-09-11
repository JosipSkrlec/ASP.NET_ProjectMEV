namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class racuninekaj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Racuns", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Racuns", new[] { "Customer_Id" });
            AddColumn("dbo.Racuns", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Racuns", "User_Id");
            AddForeignKey("dbo.Racuns", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Racuns", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Racuns", "Customer_Id", c => c.Int());
            DropForeignKey("dbo.Racuns", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Racuns", new[] { "User_Id" });
            DropColumn("dbo.Racuns", "User_Id");
            CreateIndex("dbo.Racuns", "Customer_Id");
            AddForeignKey("dbo.Racuns", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
