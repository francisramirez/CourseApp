using System;


namespace CourseAdmin.WebUi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string StartDate { get; set; }
        public int? Administrador { get; set; }

    }
}
