using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class JobType
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 工作類型 
        /// 校長,副校長,人事(主任,人員),會計處(主任,人員),
        /// 學務處
        /// 資訊設計學院->資訊工程學系->主任->導師
        /// 資訊設計學院->資管工程學系->主任->導師
        /// 教育學院->英美語文學系->主任->導師
        /// 教務處(主任,人員)
        /// 資訊處(主任,工程師)
        /// </summary>
        public string JobTypeName { get; set; }

        public int? SchoolDepartmentId { get; set; }
        public int? SchoolCollegeId { get; set; }

        
        public virtual SchoolDepartment SchoolDepartment { get; set; }
        public virtual SchoolCollege SchoolCollege { get; set; }
        public virtual IList<ProcessNodeTable> ProcessNodeTable { get; set; }
        public virtual IList<ApplicationUser> ApplicationUser { get; set; }
    }
}
