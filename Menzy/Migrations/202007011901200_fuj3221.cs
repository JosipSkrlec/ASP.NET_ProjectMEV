namespace Menzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuj3221 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        EmailStud = c.String(nullable: false),
                        TipStudentaId = c.Byte(nullable: false),
                        Birthdate = c.DateTime(),
                        KojiFaks = c.String(),
                        JMBAG = c.String(maxLength: 10),
                        Redovni = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
