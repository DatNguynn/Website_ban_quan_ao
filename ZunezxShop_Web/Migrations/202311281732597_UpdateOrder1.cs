namespace ZunezxShop_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Order", "CustomerName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.tb_Order", "Phone", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.tb_Order", "Address", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Order", "Address", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Order", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.tb_Order", "CustomerName", c => c.String(maxLength: 150));
        }
    }
}
