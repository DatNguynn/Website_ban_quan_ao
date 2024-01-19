namespace ZunezxShop_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatteAdv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Adv", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Adv", "IsActive");
        }
    }
}
