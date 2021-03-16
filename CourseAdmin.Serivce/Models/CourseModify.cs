using System;

namespace CourseAdmin.Serivce.Models
{
    public class CourseModify
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
         public int UserMod { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
