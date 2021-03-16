using CourseAdmin.Serivce.Core;
using CourseAdmin.Serivce.Models;
using System.Threading.Tasks;

namespace CourseAdmin.Serivce.Contracts
{
    public interface ICourseService
    {
        Task<CourseServiceResult> GetCourseInfoById(int courseId);
        CourseServiceResult GetCourses();
        Task<CourseServiceResult> SaveCourse(CourseSaveModel deparment);

        Task<CourseServiceResult> ModifyCourse(CourseModify courseModify);
    }
}
