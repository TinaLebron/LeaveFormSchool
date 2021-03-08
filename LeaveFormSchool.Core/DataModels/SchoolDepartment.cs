using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class SchoolDepartment
    {
        [Key]
        public int Id { get; set; }
        public string Department { get; set; }//ex: 校長室,副校長室,人事處,會計處,學務處,教務處,資訊處

        public virtual IList<JobType> JobType { get; set; }
    }
}
