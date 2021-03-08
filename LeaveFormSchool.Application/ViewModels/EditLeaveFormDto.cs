using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Application.ViewModels
{
    public class EditLeaveFormDto
    {
        
        public int ProcessInstanceTablesId { get; set; }
        public int LeaveFormId { get; set; }
        public string TypeOfLeave { get; set; }
        public string Agent { get; set; }
        public string EditBeginDate { get; set; }
        public string EditEndDate { get; set; }
        public int Total { get; set; }
        public string EditReason { get; set; }
    }
}
