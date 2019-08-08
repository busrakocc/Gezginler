namespace gezginler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rehbers",
                c => new
                    {
                        RehberId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 50),
                        Icerik = c.String(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Uye_UyeId = c.Int(),
                    })
                .PrimaryKey(t => t.RehberId)
                .ForeignKey("dbo.Uyes", t => t.Uye_UyeId)
                .Index(t => t.Uye_UyeId);
            
            CreateTable(
                "dbo.Uyes",
                c => new
                    {
                        UyeId = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(nullable: false, maxLength: 50),
                        EPosta = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UyeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rehbers", "Uye_UyeId", "dbo.Uyes");
            DropIndex("dbo.Rehbers", new[] { "Uye_UyeId" });
            DropTable("dbo.Uyes");
            DropTable("dbo.Rehbers");
        }
    }
}
