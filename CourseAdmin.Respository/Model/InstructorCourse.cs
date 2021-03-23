using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAdmin.Respository.Model
{
    public class InstructorCourse
    {
        public int InstructorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public string Course { get; set; }
    }
}
