namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifi2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "Racun_Id", "dbo.Racuns");
            DropIndex("dbo.Foods", new[] { "Racun_Id" });
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
            
            DropColumn("dbo.Foods", "Racun_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Racun_Id", c => c.Int());
            DropForeignKey("dbo.Stavkas", "Racun_Id", "dbo.Racuns");
            DropForeignKey("dbo.Stavkas", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Stavkas", new[] { "Racun_Id" });
            DropIndex("dbo.Stavkas", new[] { "Food_Id" });
            DropTable("dbo.Stavkas");
            CreateIndex("dbo.Foods", "Racun_Id");
            AddForeignKey("dbo.Foods", "Racun_Id", "dbo.Racuns", "Id");
        }
    }
}
