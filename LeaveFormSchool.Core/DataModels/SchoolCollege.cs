using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class SchoolCollege
    {
        [Key]
        public int Id { get; set; }
        public string College { get; set; }//ex: 資訊設計學院,教育學院
        public string Department { get; set; }//ex: 資訊工程學系、資管工程學系(資訊設計學院),英美語文學系(教育學院)

        public virtual IList<JobType> JobType { get; set; }
    }
}
