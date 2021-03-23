using CourseAdmin.Respository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAdmin.WebUi.ViewModels
{
    public class IntructorViewModel
    {
        public Instructor Instructor { get; set; }
        public List<InstructorCourse> InstructorCourses { get; set; }
    }
}
