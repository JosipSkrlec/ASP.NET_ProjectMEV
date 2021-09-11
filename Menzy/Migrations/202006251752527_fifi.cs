namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Racuns", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Racuns", new[] { "Food_Id" });
            AddColumn("dbo.Foods", "Racun_Id", c => c.Int());
            CreateIndex("dbo.Foods", "Racun_Id");
            AddForeignKey("dbo.Foods", "Racun_Id", "dbo.Racuns", "Id");
            DropColumn("dbo.Racuns", "Broj");
            DropColumn("dbo.Racuns", "Food_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Racuns", "Food_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Racuns", "Broj", c => c.Int(nullable: false));
            DropForeignKey("dbo.Foods", "Racun_Id", "dbo.Racuns");
            DropIndex("dbo.Foods", new[] { "Racun_Id" });
            DropColumn("dbo.Foods", "Racun_Id");
            CreateIndex("dbo.Racuns", "Food_Id");
            AddForeignKey("dbo.Racuns", "Food_Id", "dbo.Foods", "Id", cascadeDelete: true);
        }
    }
}
