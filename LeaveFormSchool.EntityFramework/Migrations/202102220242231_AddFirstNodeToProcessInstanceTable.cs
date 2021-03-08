namespace LeaveFormSchool.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstNodeToProcessInstanceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProcessInstanceTables", "FirstNodeSN", c => c.String(nullable: false));
            AddColumn("dbo.ProcessInstanceTables", "FirstProcessNodeTableId", c => c.Int(nullable: false));
            AddColumn("dbo.ProcessInstanceTableLogs", "FirstNodeSN", c => c.String(nullable: false));
            AddColumn("dbo.ProcessInstanceTableLogs", "FirstProcessNodeTableId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProcessInstanceTableLogs", "FirstProcessNodeTableId");
            DropColumn("dbo.ProcessInstanceTableLogs", "FirstNodeSN");
            DropColumn("dbo.ProcessInstanceTables", "FirstProcessNodeTableId");
            DropColumn("dbo.ProcessInstanceTables", "FirstNodeSN");
        }
    }
}
