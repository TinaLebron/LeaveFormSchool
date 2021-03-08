using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Application.ViewModels
{
    public class EditLeaveFormByEmployeeDto
    {

        public int ProcessInstanceTablesId { get; set; }
        public int LeaveFormId { get; set; }
        /// <summary>
        /// 請假單編號
        /// ex: A-20210215-1
        /// </summary>
        public string LeaveFormNo { get; set; }
        public string TypeOfLeave { get; set; }
        public string Agent { get; set; }
        public string AddBeginDate { get; set; }
        public string AddEndDate { get; set; }
        public int Total { get; set; }
        public string AddReason { get; set; }
    }
}
