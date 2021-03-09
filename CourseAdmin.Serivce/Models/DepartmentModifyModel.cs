using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAdmin.Serivce.Models
{
    public class DepartmentModifyModel
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string StartDate { get; set; }
        public int? Administrator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserMod { get; set; }

    }
}
