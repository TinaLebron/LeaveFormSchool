namespace LeaveFormSchool.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeaveFormNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProcessInstanceTables", "LeaveFormNo", c => c.String(nullable: false));
            AddColumn("dbo.LeaveForms", "LeaveFormNo", c => c.String(nullable: false));
            AddColumn("dbo.ProcessInstanceTableLogs", "LeaveFormNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProcessInstanceTableLogs", "LeaveFormNo");
            DropColumn("dbo.LeaveForms", "LeaveFormNo");
            DropColumn("dbo.ProcessInstanceTables", "LeaveFormNo");
        }
    }
}
