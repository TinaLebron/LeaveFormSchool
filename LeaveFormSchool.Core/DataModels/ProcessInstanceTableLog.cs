using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    /// <summary>
    /// 流程實例表Log
    /// </summary>
    public class ProcessInstanceTableLog
    {
        [Key]
        public int Id { get; set; }

        public string Remarks { get; set; }

        /// <summary>
        /// 目前節點
        /// </summary>
        [MaxLength()]
        [Required]
        public string NodeSN { get; set; }

        /// <summary>
        /// 目前節點名稱
        /// </summary>
        [MaxLength()]
        public string NodeName { get; set; }

        /// <summary>
        /// 申請狀態Id
        /// </summary>
        public int PITStatusId { get; set; }

        /// <summary>
        /// 請假單編號
        /// ex: A-20210215-1
        /// </summary>
        [Required]
        public string LeaveFormNo { get; set; }

        /// <summary>
        /// 申請人userId
        /// </summary>
        public int StarterId { get; set; }

        /// <summary>
        /// 申請人姓名
        /// </summary>
        public string Starter { get; set; }

        /// <summary>
        /// 目前操作人userId
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// 目前操作人姓名
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 待辦人Id(下一位審核的人)
        /// </summary>
        public int? ToDoerId { get; set; }

        /// <summary>
        /// 待辦人名稱
        /// </summary>
        public string ToDoer { get; set; }

        /// <summary>
        /// 流程更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }
        
        /// <summary>
        /// 申請假Id
        /// </summary>
        public int? LeaveFormId { get; set; }

        /// <summary>
        /// 目前節點表Id
        /// </summary>
        public int? ProcessNodeTableId { get; set; }

        /// <summary>
        /// 下一個節點
        /// </summary>
        [MaxLength()]
        [Required]
        public string NextNodeSN { get; set; }

        /// <summary>
        /// 第一個節點
        /// </summary>
        [MaxLength()]
        [Required]
        public string FirstNodeSN { get; set; }

        /// <summary>
        /// 第一個節點表Id
        /// </summary>
        public int FirstProcessNodeTableId { get; set; }

        /// <summary>
        /// 下一個節點表Id
        /// </summary>
        public int NextProcessNodeTableId { get; set; }

        /// <summary>
        /// 流程實例表Id
        /// </summary>
        public int? ProcessInstanceTableId { get; set; }

        public virtual PITStatus PITStatus { get; set; }
        public virtual LeaveForm LeaveForm { get; set; }
        public virtual ProcessNodeTable ProcessNodeTable { get; set; }
        public virtual ProcessInstanceTable ProcessInstanceTable { get; set; }
    }
}
