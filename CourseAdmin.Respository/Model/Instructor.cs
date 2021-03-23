using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAdmin.Respository.Model
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Discriminator { get; set; }
        public int CourseId { get; set; }
    }
}
