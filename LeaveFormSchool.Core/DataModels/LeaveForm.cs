using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    //請假單
    public class LeaveForm
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 請假單編號
        /// ex: A-20210215-1
        /// </summary>
        [Required]
        public string LeaveFormNo { get; set; }

        /// <summary>
        /// 申請人
        /// </summary>
        public string ApplicantName { get; set; }

        /// <summary>
        /// 員工/學號(帳號)
        /// </summary>
        public string LogonId { get; set; }

        /// <summary>
        /// 请假類型
        /// </summary>
        public int TypeOfLeaveId { get; set; }

        /// <summary>
        /// 代理人的帳號
        /// </summary>
        public string AgentLogonId { get; set; }

        /// <summary>
        /// 请假原因
        /// </summary>
        [MaxLength()]
        public string Reason { get; set; }

        /// <summary>
        /// 請假時數
        /// </summary>
        public int TimeOff { get; set; }

        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime? EndDate { get; set; }
        
        /// <summary>
        /// 創建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 創建者
        /// </summary>
        public int CreatedById { get; set; }

        /// <summary>
        /// 最後編輯的使用者
        /// </summary>
        public int? LastModifierUserId { get; set; }

        /// <summary>
        /// 最後編輯的時間
        /// </summary>
        public DateTime? LastModifierTime { get; set; } 

        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 申請人Id
        /// </summary>
        public int ApplicationUserId { get; set; }

        public virtual TypeOfLeave TypeOfLeave { get; set; }//请假類型

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual IList<LeaveFormCertifiedDoc> LeaveFormCertifiedDoc { get; set; }
        public virtual IList<ProcessInstanceTable> ProcessInstanceTable { get; set; }

    }
}
