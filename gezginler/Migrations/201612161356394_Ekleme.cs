namespace gezginler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ekleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uyes", "Parola", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uyes", "Parola");
        }
    }
}
