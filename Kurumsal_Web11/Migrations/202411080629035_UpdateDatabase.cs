namespace Kurumsal_Web11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hakkimizda", "Aciklama", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hakkimizda", "Aciklama", c => c.String(nullable: false));
        }
    }
}
