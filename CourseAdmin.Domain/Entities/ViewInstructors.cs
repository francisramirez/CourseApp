using System;
namespace CourseAdmin.Domain.Entities
{
    public class ViewInstructors
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? HireDate { get; set; }
        public int CourseId { get; set; }
        public string Course { get; set; }

    }
}
