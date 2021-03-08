using LeaveFormSchool.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LogonId { get; set; } // 員工/學號(帳號)
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; } //性別(男:M,女:F)
        public DateTime BirthDate { get; set; }
        [Required]
        public string IDNo { get; set; } //身分證
        public bool LockoutEnabled { get; set; }
        public bool EmailConfirmed { get; set; }
        public int CreatedUserId { get; set; } //建立者
        public DateTime? CreateDate { get; set; } //建立時間
        public DateTime? EnrollmentDate { get; set; } //進入學校時間
        public DateTime? GraduationDate { get; set; } //畢業時間
        public DateTime? DropOutDate { get; set; } //開始休學的時間,如果學生狀態不是休學,此欄位就為null
        public DateTime? LeaveDate { get; set; } //最後離開學校的時間
        public int LastModifierUserId { get; set; } //最後編輯的使用者
        public DateTime? LastModifierTime { get; set; } //最後編輯的時間
        public Identity Identity { get; set; } //身份(員工:0,學生:1)
        public int UserStateId { get; set; } //在學校的狀況
        public int? JobTypeId { get; set; } //工作類型Id


        public virtual UserState UserState { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual IList<LeaveForm> LeaveForm { get; set; }
        public virtual IList<Student> Student { get; set; }
        public virtual IList<Employee> Employee { get; set; }
    }
}
