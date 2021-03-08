using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Application.ViewModels
{
    public class LeaveFormList
    {
        public int ProcessInstanceTablesId { get; set; }
        public int LeaveFormId { get; set; }
        /// <summary>
        /// 申請人
        /// ex: 林XX (Z12345678)
        /// </summary>
        public string StarterString { get; set; }
        /// <summary>
        /// 請假單編號
        /// ex: A-20210215-1
        /// </summary>
        public string LeaveFormNo { get; set; }
        /// <summary>
        /// 請假類型
        /// </summary>
        public string TypeOfLeaveName { get; set; }
        /// <summary>
        /// 請假開始時間
        /// ex: 2021/04/25 13:00
        /// </summary>
        public string BeginDate { get; set; }
        /// <summary>
        /// 請假結束時間
        /// ex: 2021/04/25 13:00
        /// </summary>
        public string EndDate { get; set; }
        public bool IsUserEmp { get; set; }
        /// <summary>
        /// 假單情況
        /// </summary>
        public string Status { get; set; }
    }
}
