using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class GetLeaveStatusFormByEmployees
    {
        [Key]
        public int Id { get; set; }
        public string LogonId { get; set; }
        public string TypeOfLeaveName { get; set; }
        public int TotalLeaveHR { get; set; }
        public int RemainingLeaveHR { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LeaveRulesString { get; set; }
        public int TypeOfLeavesID { get; set; }

    }
}
