using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.EntityFramework.EntityFramework.SeedData
{
    public class InitialLeaveFormSchooltDbBuilder
    {
        private readonly LeaveFormSchoolContext _context;

        public InitialLeaveFormSchooltDbBuilder(LeaveFormSchoolContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new SchoolInitializer(_context).Create();

            _context.SaveChanges();
        }
    }
}
