using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    /// <summary>
    /// 節點表
    /// </summary>
    public class ProcessNodeTable
    {

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 節點編號
        /// </summary>
        [MaxLength()]
        [Required]
        public string NodeSN { get; set; }

        /// <summary>
        /// 節點名稱
        /// 例如: 校長審核
        /// </summary>
        [MaxLength()]
        [Required]
        public string NodeName { get; set; }

        /// <summary>
        /// 節點順位
        /// </summary>
        public int NodeOrder { get; set; }

        /// <summary>
        /// 要跑幾次流程
        /// </summary>
        public int? NumberOfTimes { get; set; }
        
        /// <summary>
        /// 最低請假數
        /// </summary>
        public int MinLeaveNum { get; set; }

        /// <summary>
        /// 工作類型名稱
        /// </summary>
        public string JobTypeName { get; set; }

        /// <summary>
        /// 工作類型Id
        /// </summary>
        public int? JobTypeId { get; set; }
        
        /// <summary>
        /// 下一節點編號
        /// </summary>
        public string NextNodeSN { get; set; }

        /// <summary>
        /// 上一節點編號（退回節點）
        /// </summary>
        public string LastNodeSN { get; set; }

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 創建者
        /// </summary>
        public int CreatedById { get; set; }
        

        public virtual JobType JobType { get; set; }

        public virtual IList<ProcessInstanceTable> ProcessInstanceTable { get; set; }

    }
}
