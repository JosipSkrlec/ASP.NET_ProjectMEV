namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuj321 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RacunFoods", "Racun_Id", "dbo.Racuns");
            DropForeignKey("dbo.RacunFoods", "Food_Id", "dbo.Foods");
            DropIndex("dbo.RacunFoods", new[] { "Racun_Id" });
            DropIndex("dbo.RacunFoods", new[] { "Food_Id" });
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Food_Id = c.Int(),
                        Racun_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.Food_Id)
                .ForeignKey("dbo.Racuns", t => t.Racun_Id)
                .Index(t => t.Food_Id)
                .Index(t => t.Racun_Id);
            
            DropTable("dbo.RacunFoods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RacunFoods",
                c => new
                    {
                        Racun_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Racun_Id, t.Food_Id });
            
            DropForeignKey("dbo.Stavkas", "Racun_Id", "dbo.Racuns");
            DropForeignKey("dbo.Stavkas", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Stavkas", new[] { "Racun_Id" });
            DropIndex("dbo.Stavkas", new[] { "Food_Id" });
            DropTable("dbo.Stavkas");
            CreateIndex("dbo.RacunFoods", "Food_Id");
            CreateIndex("dbo.RacunFoods", "Racun_Id");
            AddForeignKey("dbo.RacunFoods", "Food_Id", "dbo.Foods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RacunFoods", "Racun_Id", "dbo.Racuns", "Id", cascadeDelete: true);
        }
    }
}
