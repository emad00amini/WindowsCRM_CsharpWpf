namespace DAL_CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogCreatedTimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.invoices", "deleteStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.invoices", "deleteStatus");
        }
    }
}
