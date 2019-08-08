namespace gezginler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeniekleme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resims",
                c => new
                    {
                        ResimId = c.Int(nullable: false, identity: true),
                        Resimyol = c.String(),
                        Uye_UyeId = c.Int(),
                    })
                .PrimaryKey(t => t.ResimId)
                .ForeignKey("dbo.Uyes", t => t.Uye_UyeId)
                .Index(t => t.Uye_UyeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resims", "Uye_UyeId", "dbo.Uyes");
            DropIndex("dbo.Resims", new[] { "Uye_UyeId" });
            DropTable("dbo.Resims");
        }
    }
}
