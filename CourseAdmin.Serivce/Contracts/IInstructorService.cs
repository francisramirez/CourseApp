using CourseAdmin.Respository.Model;
using CourseAdmin.Serivce.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseAdmin.Serivce.Contracts
{
    public interface IInstructorService
    {
        Task<InstructorResult> AddInstructor(Instructor instructor);

        InstructorResult GetInstructorCourses();

        InstructorResult GetInstructorCourses(int courseId, DateTime startDate, DateTime endDate);
    }
}
