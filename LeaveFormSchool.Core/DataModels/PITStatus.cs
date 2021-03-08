using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class PITStatus
    {

        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 狀態code
        /// Applied,Accepted,Canceled,Finished,Rejected
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 狀態名稱
        /// 已申請,已受理,已撤銷,已同意,不受理
        /// </summary>
        public string Name { get; set; }
        public string NextStatusCode { get; set; }

        public virtual IList<ProcessInstanceTable> ProcessInstanceTable { get; set; }
    }
}
