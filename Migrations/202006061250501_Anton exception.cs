namespace OIDt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Antonexception : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditsPurchases", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.ItemPurchases", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemPurchases", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.CreditsPurchases", "Price", c => c.Int(nullable: false));
        }
    }
}
