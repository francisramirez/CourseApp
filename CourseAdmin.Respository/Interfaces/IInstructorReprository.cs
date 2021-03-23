using CourseAdmin.Respository.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
namespace CourseAdmin.Respository.Interfaces
{
    public interface IInstructorReprository 
    {
        Task AddInstructor(Instructor instructor);

        List<InstructorCourse> GetInstructorCourses();

        List<InstructorCourse> GetInstructorCourses(int courseId, DateTime startDate, DateTime endDate);

    }
}
