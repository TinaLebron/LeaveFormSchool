namespace LeaveFormSchool.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Text;

    public partial class GetLeaveStatusFormByEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GetLeaveStatusFormByEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogonId = c.String(),
                        TypeOfLeaveName = c.String(),
                        TotalLeaveHR = c.Int(nullable: false),
                        RemainingLeaveHR = c.Int(nullable: false),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        LeaveRulesString = c.String(),
                        TypeOfLeavesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            StringBuilder storedProcedureCode = new StringBuilder();

            string procedure = @"create procedure dbo.GetLeaveStatusFormByEmployees_InsertAndUpdate
	            @LogonId nvarchar(max)
            AS
            BEGIN	
	            DECLARE @BeginDate datetime
	            DECLARE @EndDate datetime
                --特休假
	            DECLARE @TotalLeaveHR1 int
	            DECLARE @RemainingLeaveHR1 int
	            DECLARE @LeaveRulesString1 nvarchar(max)
	            DECLARE @TypeOfLeavesID1 int
	            --事假
	            DECLARE @TotalLeaveHR2 int
	            DECLARE @RemainingLeaveHR2 int
	            DECLARE @LeaveRulesString2 nvarchar(max)
	            DECLARE @TypeOfLeavesID2 int
	            --生理假
	            DECLARE @TotalLeaveHR3 int
	            DECLARE @RemainingLeaveHR3 int
	            DECLARE @LeaveRulesString3 nvarchar(max)
	            DECLARE @TypeOfLeavesID3 int


            ----------特休假--------------------------------

            DECLARE @totalYear1 int
            DECLARE @totalDay int
            DECLARE @dateNow Date set @dateNow=CAST( GETDATE() AS Date )

            --(現在時間-進學校的時間)/365 = 在職幾年
            SELECT @totalYear1 =  DATEDIFF(day,CAST( t1.EnrollmentDate AS Date ), @dateNow)/365 from [dbo].[ApplicationUsers] t1 where t1.LogonId = @LogonId
            --現在時間-進學校的時間 = 在職天數 (判斷是否在職半年)
            SELECT @totalDay =  DATEDIFF(day,CAST( t1.EnrollmentDate AS Date ), @dateNow) from [dbo].[ApplicationUsers] t1 where t1.LogonId = @LogonId 

            SELECT @BeginDate =  DATEADD(day, 365*(DATEDIFF(day,CAST( t1.EnrollmentDate AS Date ), @dateNow)/365),CAST( t1.EnrollmentDate AS Date )) from [dbo].[ApplicationUsers] t1 where t1.LogonId = @LogonId  
            SELECT @EndDate =  DATEADD(day, (365*(1+(DATEDIFF(day,CAST( t1.EnrollmentDate AS Date ), @dateNow)/365)))-1,CAST( t1.EnrollmentDate AS Date )) from [dbo].[ApplicationUsers] t1 where t1.LogonId = @LogonId 

            --特休假規則(一天8hr)-----------------
            IF @totalYear1=0 and @totalDay>183
            begin
	            SELECT @TotalLeaveHR1=3*8
	            SELECT @BeginDate =  DATEADD(day, 184,CAST( t1.EnrollmentDate AS Date )) from [dbo].[ApplicationUsers] t1 where t1.LogonId = @LogonId  
            end
            ELSE IF 1<=@totalYear1 and @totalYear1<2
	            SELECT @TotalLeaveHR1=7*8
            ELSE IF 2<=@totalYear1 and @totalYear1<3
            SELECT @TotalLeaveHR1=10*8
            ELSE IF 3<=@totalYear1 and @totalYear1<5
            SELECT @TotalLeaveHR1=14*8
            ELSE IF 5<=@totalYear1 and @totalYear1<10
            SELECT @TotalLeaveHR1=15*8
            ELSE IF 10<=@totalYear1 and @totalYear1<24
            SELECT @TotalLeaveHR1=(@totalYear1+6)*8
            ELSE IF 24<=@totalYear1
            SELECT @TotalLeaveHR1=30*8
            ELSE
	            SELECT @TotalLeaveHR1=0*8
            --------------------------------

            --TotalLeaveForms-使用者已申請假單(包含:申請過的跟待審核的)(TimeOff是小時為單位)
            DECLARE @TotalLeaveFormsHR1 int
            SELECT @TotalLeaveFormsHR1 = isnull(sum(t1.TimeOff),0)  from [dbo].[LeaveForms] t1 
            where t1.LogonId = @LogonId and t1.TypeOfLeaveId = 1 and t1.IsDelete = 0 and @BeginDate <= t1.BeginDate and t1.BeginDate <= @EndDate

            --剩餘請假時數
            set @RemainingLeaveHR1 = @TotalLeaveHR1-@TotalLeaveFormsHR1

            set @LeaveRulesString1 = '有'+CAST((@TotalLeaveHR1/8) as varchar(10))+'天,剩下'+CAST((@RemainingLeaveHR1/8) as varchar(10))+'天又'+CAST((@RemainingLeaveHR1%8) as varchar(10))+'小時('+convert(varchar, CAST( @BeginDate AS Date ), 120)+' ~ '+convert(varchar, CAST( @EndDate AS Date ), 120)+')'

            --取TypeOfLeaves的id
            SELECT @TypeOfLeavesID1 = t1.Id from [dbo].[TypeOfLeaves] t1 where t1.TypeOfLeaveName = '特休假'

            --此數量用來判斷員工是否在GetLeaveStatusFormByEmployees表裡,如果沒有就新增,有就修改
            DECLARE @countGetLeaveStatusFormByEmployees1 int
            SELECT @countGetLeaveStatusFormByEmployees1 = count(t1.Id) from [dbo].[GetLeaveStatusFormByEmployees] t1 where t1.LogonId = @LogonId and t1.TypeOfLeavesID = 1

            --判斷員工是否在GetLeaveStatusFormByEmployees表裡,如果沒有就新增,有就修改
            IF @countGetLeaveStatusFormByEmployees1>0
            begin
	            UPDATE GetLeaveStatusFormByEmployees SET LogonId = @LogonId,TotalLeaveHR=@TotalLeaveHR1,RemainingLeaveHR=@RemainingLeaveHR1,BeginDate=@BeginDate,EndDate=@EndDate,LeaveRulesString=@LeaveRulesString1 WHERE LogonId = @LogonId and TypeOfLeavesID = 1
            end
            ELSE
            begin
	            INSERT INTO GetLeaveStatusFormByEmployees (LogonId,TypeOfLeaveName, TotalLeaveHR, RemainingLeaveHR,BeginDate,EndDate,LeaveRulesString,TypeOfLeavesID)
	            VALUES 
	            ( @LogonId,'特休假',@TotalLeaveHR1 ,@RemainingLeaveHR1,@BeginDate,@EndDate,@LeaveRulesString1,@TypeOfLeavesID1)
            end

            ------------------------------------------

            ----------事假--------------------------------

            --剩餘請假天數
            set @TotalLeaveHR2 = 14*8

            --TotalLeaveForms-使用者已申請假單(包含:申請過的跟待審核的)(TimeOff是小時為單位)
            DECLARE @TotalLeaveFormsHR2 int
            SELECT @TotalLeaveFormsHR2 = isnull(sum(t1.TimeOff),0) from [dbo].[LeaveForms] t1 
            where t1.LogonId = @LogonId and t1.TypeOfLeaveId = 3 and t1.IsDelete = 0 and @BeginDate <= t1.BeginDate and t1.BeginDate <= @EndDate

            --剩餘請假時數
            set @RemainingLeaveHR2 = @TotalLeaveHR2-@TotalLeaveFormsHR2

            set @LeaveRulesString2 = '有'+CAST((@TotalLeaveHR2/8) as varchar(10))+'天,剩下'+CAST((@RemainingLeaveHR2/8) as varchar(10))+'天又'+CAST((@RemainingLeaveHR2%8) as varchar(10))+'小時('+convert(varchar, CAST( @BeginDate AS Date ), 120)+' ~ '+convert(varchar, CAST( @EndDate AS Date ), 120)+')'

            --取TypeOfLeaves的id
            SELECT @TypeOfLeavesID2 = t1.Id from [dbo].[TypeOfLeaves] t1 where t1.TypeOfLeaveName = '事假'

            --此數量用來判斷員工是否在GetLeaveStatusFormByEmployees表裡,如果沒有就新增,有就修改
            DECLARE @countGetLeaveStatusFormByEmployees2 int
            SELECT @countGetLeaveStatusFormByEmployees2 = count(t1.Id) from [dbo].[GetLeaveStatusFormByEmployees] t1 where t1.LogonId = @LogonId and t1.TypeOfLeavesID = 3

            --判斷員工是否在GetLeaveStatusFormByEmployees表裡,如果沒有就新增,有就修改
            IF @countGetLeaveStatusFormByEmployees2>0
            begin
	            UPDATE GetLeaveStatusFormByEmployees SET LogonId = @LogonId,TotalLeaveHR=@TotalLeaveHR2,RemainingLeaveHR=@RemainingLeaveHR2,BeginDate=@BeginDate,EndDate=@EndDate,LeaveRulesString=@LeaveRulesString2 WHERE LogonId = @LogonId and TypeOfLeavesID = 3
            end
            ELSE
            begin
	            INSERT INTO GetLeaveStatusFormByEmployees (LogonId,TypeOfLeaveName, TotalLeaveHR, RemainingLeaveHR,BeginDate,EndDate,LeaveRulesString,TypeOfLeavesID)
	            VALUES 
	            ( @LogonId,'事假',@TotalLeaveHR2 ,@RemainingLeaveHR2,@BeginDate,@EndDate,@LeaveRulesString2,@TypeOfLeavesID2)
            end

            ------------------------------------------

            ----------生理假--------------------------------

            --剩餘請假天數
            set @TotalLeaveHR3 = 3*8

            --TotalLeaveForms-使用者已申請假單(包含:申請過的跟待審核的)(TimeOff是小時為單位)
            DECLARE @TotalLeaveFormsHR3 int
            SELECT @TotalLeaveFormsHR3 = isnull(sum(t1.TimeOff),0)  from [dbo].[LeaveForms] t1 
            where t1.LogonId = @LogonId and t1.TypeOfLeaveId = 12 and t1.IsDelete = 0 and @BeginDate <= t1.BeginDate and t1.BeginDate <= @EndDate

            --剩餘請假時數
            set @RemainingLeaveHR3 = @TotalLeaveHR3-@TotalLeaveFormsHR3

            set @LeaveRulesString3 = '有'+CAST((@TotalLeaveHR3/8) as varchar(10))+'天,剩下'+CAST((@RemainingLeaveHR3/8) as varchar(10))+'天又'+CAST((@RemainingLeaveHR3%8) as varchar(10))+'小時('+convert(varchar, CAST( @BeginDate AS Date ), 120)+' ~ '+convert(varchar, CAST( @EndDate AS Date ), 120)+')'

            --取TypeOfLeaves的id
            SELECT @TypeOfLeavesID3 = t1.Id from [dbo].[TypeOfLeaves] t1 where t1.TypeOfLeaveName = '生理假'


            --此數量用來判斷員工是否在GetLeaveStatusFormByEmployees表裡,如果沒有就新增,有就修改
            DECLARE @countGetLeaveStatusFormByEmployees3 int
            SELECT @countGetLeaveStatusFormByEmployees3 = count(t1.Id) from [dbo].[GetLeaveStatusFormByEmployees] t1 where t1.LogonId = @LogonId and t1.TypeOfLeavesID = 12

            --判斷員工是否在GetLeaveStatusFormByEmployees表裡,如果沒有就新增,有就修改
            IF @countGetLeaveStatusFormByEmployees3>0
            begin
	            UPDATE GetLeaveStatusFormByEmployees SET LogonId = @LogonId,TotalLeaveHR=@TotalLeaveHR3,RemainingLeaveHR=@RemainingLeaveHR3,BeginDate=@BeginDate,EndDate=@EndDate,LeaveRulesString=@LeaveRulesString3 WHERE LogonId = @LogonId and TypeOfLeavesID = 12
            end
            ELSE
            begin
	            INSERT INTO GetLeaveStatusFormByEmployees (LogonId,TypeOfLeaveName, TotalLeaveHR, RemainingLeaveHR,BeginDate,EndDate,LeaveRulesString,TypeOfLeavesID)
	            VALUES 
	            ( @LogonId,'生理假',@TotalLeaveHR3,@RemainingLeaveHR3,@BeginDate,@EndDate,@LeaveRulesString3,@TypeOfLeavesID3)
            end

            ------------------------------------------

            select * from GetLeaveStatusFormByEmployees where LogonId = @LogonId

            END
            GO";


            storedProcedureCode.Append(procedure);

            this.Sql(storedProcedureCode.ToString());

        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.GetLeaveStatusFormByEmployees_InsertAndUpdate");
            DropTable("dbo.GetLeaveStatusFormByEmployees");
        }
    }
}
