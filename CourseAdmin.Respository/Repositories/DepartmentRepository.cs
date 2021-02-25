using CourseAdmin.Respository.Interfaces;
using CourseAdmin.Respository.BaseRepository;
using CourseAdmin.Domain.Entities;
using CourseAdmin.Respository.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseAdmin.Respository.Repositories
{
    public class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {
        private readonly SchoolContext schoolContext;
        public DepartmentRepository(SchoolContext school) : base(school)
        {
            this.schoolContext = school;
        }

        public IEnumerable<Department> GetDepartmests()
        {
            return base.FindAll(cd => !cd.Deleted);
        }
        
    }
}
