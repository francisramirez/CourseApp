using CourseAdmin.Domain.Entities;
using CourseAdmin.Respository.BaseRepository;
using CourseAdmin.Respository.Context;
using CourseAdmin.Respository.Interfaces;

namespace CourseAdmin.Respository.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext school):base(school)
        {

        }
    }
}
