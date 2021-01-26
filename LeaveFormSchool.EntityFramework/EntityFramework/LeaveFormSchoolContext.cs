using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.EntityFramework.EntityFramework
{
    public class LeaveFormSchoolContext : IdentityDbContext<IdentityUser>
    {
        public LeaveFormSchoolContext() : base("LeaveFormSchoolContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
