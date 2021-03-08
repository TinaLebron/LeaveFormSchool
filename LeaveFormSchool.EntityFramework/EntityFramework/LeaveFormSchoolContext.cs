using LeaveFormSchool.Core.DataModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeaveFormSchool.EntityFramework.EntityFramework
{
    public class LeaveFormSchoolContext : DbContext
    {
        public LeaveFormSchoolContext() : base("LeaveFormSchoolContext")
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<CertifiedDoc> CertifiedDoc { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<LeaveForm> LeaveForm { get; set; }
        public DbSet<LeaveFormCertifiedDoc> LeaveFormCertifiedDoc { get; set; }
        public DbSet<PITStatus> PITStatus { get; set; }
        public DbSet<ProcessInstanceTable> ProcessInstanceTable { get; set; }
        public DbSet<ProcessInstanceTableLog> ProcessInstanceTableLog { get; set; }
        public DbSet<ProcessNodeTable> ProcessNodeTable { get; set; }
        public DbSet<SchoolCollege> SchoolCollege { get; set; }
        public DbSet<SchoolDepartment> SchoolDepartment { get; set; }
        public DbSet<SectionDepartment> SectionDepartment { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<TypeOfLeave> TypeOfLeave { get; set; }
        public DbSet<UserState> UserState { get; set; }
        public DbSet<GetLeaveStatusFormByEmployees> GetLeaveStatusForm { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GetLeaveStatusFormByEmployees>().MapToStoredProcedures();
        }

    }
}
