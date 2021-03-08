using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class LeaveFormCertifiedDoc
    {
        [Key]
        public int Id { get; set; }
        public int LeaveFormId { get; set; }
        public int CertifiedDocId { get; set; } 

        public virtual LeaveForm LeaveForm { get; set; }
        public virtual CertifiedDoc CertifiedDoc { get; set; }
    }
}
