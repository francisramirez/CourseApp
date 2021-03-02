using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAdmin.Serivce.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
    }
}
