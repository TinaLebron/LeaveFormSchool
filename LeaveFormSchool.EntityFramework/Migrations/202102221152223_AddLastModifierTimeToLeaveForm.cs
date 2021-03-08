namespace LeaveFormSchool.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastModifierTimeToLeaveForm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveForms", "LastModifierUserId", c => c.Int());
            AddColumn("dbo.LeaveForms", "LastModifierTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeaveForms", "LastModifierTime");
            DropColumn("dbo.LeaveForms", "LastModifierUserId");
        }
    }
}
