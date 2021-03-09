using CourseAdmin.Serivce.Core;
using CourseAdmin.Serivce.Models;
using System.Threading.Tasks;

namespace CourseAdmin.Serivce.Contracts
{
    public interface IDepartmentService
    {
        DeparmentServiceResult GetDepartments();
        Task<DeparmentServiceResult> SaveDeparment(DeparmentModel deparment);

        Task<DeparmentServiceResult> UpdateDeparment(DepartmentModifyModel deparment);

        Task<DeparmentServiceResult> GetDeparmentById(int Id);

        Task<DeparmentServiceResult> RemoveDepartment(DepartmentRemoveModel departmentRemove);

    }
}
