namespace LeaveFormSchool.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNextNodeToProcessInstanceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProcessInstanceTables", "NextNodeSN", c => c.String(nullable: false));
            AddColumn("dbo.ProcessInstanceTables", "NextProcessNodeTableId", c => c.Int(nullable: false));
            AddColumn("dbo.ProcessInstanceTableLogs", "NextNodeSN", c => c.String(nullable: false));
            AddColumn("dbo.ProcessInstanceTableLogs", "NextProcessNodeTableId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProcessInstanceTableLogs", "NextProcessNodeTableId");
            DropColumn("dbo.ProcessInstanceTableLogs", "NextNodeSN");
            DropColumn("dbo.ProcessInstanceTables", "NextProcessNodeTableId");
            DropColumn("dbo.ProcessInstanceTables", "NextNodeSN");
        }
    }
}
