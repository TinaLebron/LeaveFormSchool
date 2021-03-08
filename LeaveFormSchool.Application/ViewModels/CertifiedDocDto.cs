using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Application.ViewModels
{
    public class CertifiedDocDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
