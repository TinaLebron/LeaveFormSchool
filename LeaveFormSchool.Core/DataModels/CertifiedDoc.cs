using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class CertifiedDoc
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual IList<LeaveFormCertifiedDoc> LeaveFormCertifiedDoc { get; set; }
    }
}
