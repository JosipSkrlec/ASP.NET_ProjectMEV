namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuj32 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RacunFoods",
                c => new
                    {
                        Racun_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Racun_Id, t.Food_Id })
                .ForeignKey("dbo.Racuns", t => t.Racun_Id, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.Food_Id, cascadeDelete: true)
                .Index(t => t.Racun_Id)
                .Index(t => t.Food_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RacunFoods", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.RacunFoods", "Racun_Id", "dbo.Racuns");
            DropIndex("dbo.RacunFoods", new[] { "Food_Id" });
            DropIndex("dbo.RacunFoods", new[] { "Racun_Id" });
            DropTable("dbo.RacunFoods");
        }
    }
}
