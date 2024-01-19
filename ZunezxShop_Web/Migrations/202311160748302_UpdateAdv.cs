namespace ZunezxShop_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Adv", "Detail", c => c.String());
            AddColumn("dbo.tb_Adv", "Alias", c => c.String());
            DropColumn("dbo.tb_Adv", "Link");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Adv", "Link", c => c.String());
            DropColumn("dbo.tb_Adv", "Alias");
            DropColumn("dbo.tb_Adv", "Detail");
        }
    }
}
