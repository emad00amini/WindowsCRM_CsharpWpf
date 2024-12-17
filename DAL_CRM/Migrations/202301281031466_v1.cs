namespace DAL_CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.reminders", "deleteStatus", c => c.String());
            AddColumn("dbo.reminders", "user_id", c => c.Int());


        }
        
        public override void Down()
        {
            DropColumn("dbo.reminders", "deleteStatus");
            DropColumn("dbo.reminders", "user_id");
        }
    }
}
