using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class TypeOfLeave
    {

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 请假類型 
        /// 特休假,公假,事假,病假(傷病假,公傷病假),喪假,結假,產假(生產前,生產後,流產),生理假
        /// </summary>
        public string TypeOfLeaveName { get; set; }

        public virtual IList<LeaveForm> LeaveForm { get; set; }
    }
}
