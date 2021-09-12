namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class racuninekaj2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stavkas", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.Stavkas", "Racun_Id", "dbo.Racuns");
            DropIndex("dbo.Stavkas", new[] { "Food_Id" });
            DropIndex("dbo.Stavkas", new[] { "Racun_Id" });
            DropTable("dbo.Stavkas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Food_Id = c.Int(),
                        Racun_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Stavkas", "Racun_Id");
            CreateIndex("dbo.Stavkas", "Food_Id");
            AddForeignKey("dbo.Stavkas", "Racun_Id", "dbo.Racuns", "Id");
            AddForeignKey("dbo.Stavkas", "Food_Id", "dbo.Foods", "Id");
        }
    }
}
