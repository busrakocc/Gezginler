namespace gezginler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newekleme : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rehbers", "Tarih");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rehbers", "Tarih", c => c.DateTime(nullable: false));
        }
    }
}
