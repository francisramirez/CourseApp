using CourseAdmin.WebUi.Models;
using System.Collections.Generic;

namespace CourseAdmin.WebUi.ViewModels
{
    public class CourseViewModel
    {
        public int DepartmentId { get; set; }
        public List<CourseList> CourseList { get; set; }
    }
}
