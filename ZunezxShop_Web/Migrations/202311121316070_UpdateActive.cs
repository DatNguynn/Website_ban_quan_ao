namespace ZunezxShop_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_News", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Post", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "IsHome", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "IsSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "IsFeature", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "IsActive");
            DropColumn("dbo.tb_Product", "IsHot");
            DropColumn("dbo.tb_Product", "IsFeature");
            DropColumn("dbo.tb_Product", "IsSale");
            DropColumn("dbo.tb_Product", "IsHome");
            DropColumn("dbo.tb_Post", "IsActive");
            DropColumn("dbo.tb_News", "IsActive");
            DropColumn("dbo.tb_Category", "IsActive");
        }
    }
}
