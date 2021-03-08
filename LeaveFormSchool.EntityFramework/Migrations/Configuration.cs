namespace LeaveFormSchool.EntityFramework.Migrations
{
    using LeaveFormSchool.EntityFramework.EntityFramework.SeedData;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeaveFormSchool.EntityFramework.EntityFramework.LeaveFormSchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LeaveFormSchool.EntityFramework.EntityFramework.LeaveFormSchoolContext context)
        {
            //防止重複執行
            if (context.ApplicationUser.Count() == 0) { new InitialLeaveFormSchooltDbBuilder(context).Create(); }
        }
    }
}
