namespace ZunezxShop_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTitle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Adv", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.tb_Category", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.tb_News", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.tb_Post", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.tb_Product", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.tb_ProductCategory", "Title", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_ProductCategory", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Product", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Post", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_News", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.tb_Category", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.tb_Adv", "Title", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
