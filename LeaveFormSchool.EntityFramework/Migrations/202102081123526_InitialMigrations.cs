namespace LeaveFormSchool.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogonId = c.String(nullable: false),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        Email = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        IDNo = c.String(nullable: false),
                        LockoutEnabled = c.Boolean(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        CreatedUserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        EnrollmentDate = c.DateTime(),
                        GraduationDate = c.DateTime(),
                        DropOutDate = c.DateTime(),
                        LeaveDate = c.DateTime(),
                        LastModifierUserId = c.Int(nullable: false),
                        LastModifierTime = c.DateTime(),
                        Identity = c.Int(nullable: false),
                        UserStateId = c.Int(nullable: false),
                        JobTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserStates", t => t.UserStateId, cascadeDelete: true)
                .ForeignKey("dbo.JobTypes", t => t.JobTypeId)
                .Index(t => t.UserStateId)
                .Index(t => t.JobTypeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LogonId = c.String(nullable: false),
                        Annual = c.Int(nullable: false),
                        Tel = c.String(),
                        ResearchAreas = c.String(),
                        JobTitle = c.String(),
                        CreatedUserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        LastModifiedUserId = c.Int(nullable: false),
                        LastModifyDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        SectionDepartment_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .ForeignKey("dbo.SectionDepartments", t => t.SectionDepartment_ID)
                .Index(t => t.ClassroomId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.SectionDepartment_ID);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SchoolNumber = c.String(),
                        ClassroomNumber = c.String(),
                        Location = c.String(),
                        Floor = c.String(),
                        CreatedUserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        LastModifiedUserId = c.Int(nullable: false),
                        LastModifyDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SectionDepartments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Section = c.String(),
                        Department = c.String(),
                        DepartmentAbbreviation = c.String(),
                        CourseSorts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LogonId = c.String(nullable: false),
                        Annual = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        Class = c.String(),
                        CreatedUserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        LastModifiedUserId = c.Int(nullable: false),
                        LastModifyDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        SectionDepartmentId = c.Int(nullable: false),
                        UserStateId = c.Int(),
                        ClassGuideLogonId = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.SectionDepartments", t => t.SectionDepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.UserStates", t => t.UserStateId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.SectionDepartmentId)
                .Index(t => t.UserStateId);
            
            CreateTable(
                "dbo.UserStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InSchoolState = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTypeName = c.String(),
                        SchoolDepartmentId = c.Int(),
                        SchoolCollegeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolColleges", t => t.SchoolCollegeId)
                .ForeignKey("dbo.SchoolDepartments", t => t.SchoolDepartmentId)
                .Index(t => t.SchoolDepartmentId)
                .Index(t => t.SchoolCollegeId);
            
            CreateTable(
                "dbo.ProcessNodeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeSN = c.String(nullable: false),
                        NodeName = c.String(nullable: false),
                        NodeOrder = c.Int(nullable: false),
                        NumberOfTimes = c.Int(),
                        MinLeaveNum = c.Int(nullable: false),
                        JobTypeName = c.String(),
                        JobTypeId = c.Int(),
                        NextNodeSN = c.String(),
                        LastNodeSN = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobTypes", t => t.JobTypeId)
                .Index(t => t.JobTypeId);
            
            CreateTable(
                "dbo.ProcessInstanceTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeSN = c.String(nullable: false),
                        NodeName = c.String(),
                        PITStatusId = c.Int(nullable: false),
                        StarterId = c.Int(nullable: false),
                        Starter = c.String(),
                        OperatorId = c.Int(nullable: false),
                        Operator = c.String(),
                        ToDoerId = c.Int(),
                        ToDoer = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        LeaveFormId = c.Int(),
                        ProcessNodeTableId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeaveForms", t => t.LeaveFormId)
                .ForeignKey("dbo.PITStatus", t => t.PITStatusId, cascadeDelete: true)
                .ForeignKey("dbo.ProcessNodeTables", t => t.ProcessNodeTableId)
                .Index(t => t.PITStatusId)
                .Index(t => t.LeaveFormId)
                .Index(t => t.ProcessNodeTableId);
            
            CreateTable(
                "dbo.LeaveForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicantName = c.String(),
                        LogonId = c.String(),
                        TypeOfLeaveId = c.Int(nullable: false),
                        AgentLogonId = c.String(),
                        Reason = c.String(),
                        TimeOff = c.Int(nullable: false),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        CreateTime = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        Remarks = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfLeaves", t => t.TypeOfLeaveId, cascadeDelete: true)
                .Index(t => t.TypeOfLeaveId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.LeaveFormCertifiedDocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveFormId = c.Int(nullable: false),
                        CertifiedDocId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CertifiedDocs", t => t.CertifiedDocId, cascadeDelete: true)
                .ForeignKey("dbo.LeaveForms", t => t.LeaveFormId, cascadeDelete: true)
                .Index(t => t.LeaveFormId)
                .Index(t => t.CertifiedDocId);
            
            CreateTable(
                "dbo.CertifiedDocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileSize = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfLeaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfLeaveName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PITStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusCode = c.String(),
                        Name = c.String(),
                        NextStatusCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProcessInstanceTableLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Remarks = c.String(),
                        NodeSN = c.String(nullable: false),
                        NodeName = c.String(),
                        PITStatusId = c.Int(nullable: false),
                        StarterId = c.Int(nullable: false),
                        Starter = c.String(),
                        OperatorId = c.Int(nullable: false),
                        Operator = c.String(),
                        ToDoerId = c.Int(),
                        ToDoer = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        LeaveFormId = c.Int(),
                        ProcessNodeTableId = c.Int(),
                        ProcessInstanceTableId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeaveForms", t => t.LeaveFormId)
                .ForeignKey("dbo.PITStatus", t => t.PITStatusId, cascadeDelete: true)
                .ForeignKey("dbo.ProcessInstanceTables", t => t.ProcessInstanceTableId)
                .ForeignKey("dbo.ProcessNodeTables", t => t.ProcessNodeTableId)
                .Index(t => t.PITStatusId)
                .Index(t => t.LeaveFormId)
                .Index(t => t.ProcessNodeTableId)
                .Index(t => t.ProcessInstanceTableId);
            
            CreateTable(
                "dbo.SchoolColleges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        College = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolDepartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobTypes", "SchoolDepartmentId", "dbo.SchoolDepartments");
            DropForeignKey("dbo.JobTypes", "SchoolCollegeId", "dbo.SchoolColleges");
            DropForeignKey("dbo.ProcessInstanceTables", "ProcessNodeTableId", "dbo.ProcessNodeTables");
            DropForeignKey("dbo.ProcessInstanceTableLogs", "ProcessNodeTableId", "dbo.ProcessNodeTables");
            DropForeignKey("dbo.ProcessInstanceTableLogs", "ProcessInstanceTableId", "dbo.ProcessInstanceTables");
            DropForeignKey("dbo.ProcessInstanceTableLogs", "PITStatusId", "dbo.PITStatus");
            DropForeignKey("dbo.ProcessInstanceTableLogs", "LeaveFormId", "dbo.LeaveForms");
            DropForeignKey("dbo.ProcessInstanceTables", "PITStatusId", "dbo.PITStatus");
            DropForeignKey("dbo.LeaveForms", "TypeOfLeaveId", "dbo.TypeOfLeaves");
            DropForeignKey("dbo.ProcessInstanceTables", "LeaveFormId", "dbo.LeaveForms");
            DropForeignKey("dbo.LeaveFormCertifiedDocs", "LeaveFormId", "dbo.LeaveForms");
            DropForeignKey("dbo.LeaveFormCertifiedDocs", "CertifiedDocId", "dbo.CertifiedDocs");
            DropForeignKey("dbo.LeaveForms", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ProcessNodeTables", "JobTypeId", "dbo.JobTypes");
            DropForeignKey("dbo.ApplicationUsers", "JobTypeId", "dbo.JobTypes");
            DropForeignKey("dbo.Students", "UserStateId", "dbo.UserStates");
            DropForeignKey("dbo.ApplicationUsers", "UserStateId", "dbo.UserStates");
            DropForeignKey("dbo.Students", "SectionDepartmentId", "dbo.SectionDepartments");
            DropForeignKey("dbo.Students", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Employees", "SectionDepartment_ID", "dbo.SectionDepartments");
            DropForeignKey("dbo.Employees", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.ApplicationUsers");
            DropIndex("dbo.ProcessInstanceTableLogs", new[] { "ProcessInstanceTableId" });
            DropIndex("dbo.ProcessInstanceTableLogs", new[] { "ProcessNodeTableId" });
            DropIndex("dbo.ProcessInstanceTableLogs", new[] { "LeaveFormId" });
            DropIndex("dbo.ProcessInstanceTableLogs", new[] { "PITStatusId" });
            DropIndex("dbo.LeaveFormCertifiedDocs", new[] { "CertifiedDocId" });
            DropIndex("dbo.LeaveFormCertifiedDocs", new[] { "LeaveFormId" });
            DropIndex("dbo.LeaveForms", new[] { "ApplicationUserId" });
            DropIndex("dbo.LeaveForms", new[] { "TypeOfLeaveId" });
            DropIndex("dbo.ProcessInstanceTables", new[] { "ProcessNodeTableId" });
            DropIndex("dbo.ProcessInstanceTables", new[] { "LeaveFormId" });
            DropIndex("dbo.ProcessInstanceTables", new[] { "PITStatusId" });
            DropIndex("dbo.ProcessNodeTables", new[] { "JobTypeId" });
            DropIndex("dbo.JobTypes", new[] { "SchoolCollegeId" });
            DropIndex("dbo.JobTypes", new[] { "SchoolDepartmentId" });
            DropIndex("dbo.Students", new[] { "UserStateId" });
            DropIndex("dbo.Students", new[] { "SectionDepartmentId" });
            DropIndex("dbo.Students", new[] { "ApplicationUserId" });
            DropIndex("dbo.Employees", new[] { "SectionDepartment_ID" });
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropIndex("dbo.Employees", new[] { "ClassroomId" });
            DropIndex("dbo.ApplicationUsers", new[] { "JobTypeId" });
            DropIndex("dbo.ApplicationUsers", new[] { "UserStateId" });
            DropTable("dbo.SchoolDepartments");
            DropTable("dbo.SchoolColleges");
            DropTable("dbo.ProcessInstanceTableLogs");
            DropTable("dbo.PITStatus");
            DropTable("dbo.TypeOfLeaves");
            DropTable("dbo.CertifiedDocs");
            DropTable("dbo.LeaveFormCertifiedDocs");
            DropTable("dbo.LeaveForms");
            DropTable("dbo.ProcessInstanceTables");
            DropTable("dbo.ProcessNodeTables");
            DropTable("dbo.JobTypes");
            DropTable("dbo.UserStates");
            DropTable("dbo.Students");
            DropTable("dbo.SectionDepartments");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Employees");
            DropTable("dbo.ApplicationUsers");
        }
    }
}
