﻿using LeaveFormSchool.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Core.DataModels
{
    public class SectionDepartment
    {

        [Key]
        public int ID { get; set; }
        public string Section { get; set; } //部別ex:大學部
        public string Department { get; set; } //科系
        public string DepartmentAbbreviation { get; set; } //科系縮寫
        public CourseSorts CourseSorts { get; set; }//系所課程:0,共同課程:1


        public virtual IList<Employee> Employee { get; set; }
        public virtual IList<Student> Student { get; set; }
    }
}
