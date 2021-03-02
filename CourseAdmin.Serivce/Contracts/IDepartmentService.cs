using CourseAdmin.Serivce.Core;
using System.Threading.Tasks;

namespace CourseAdmin.Serivce.Contracts
{
    public interface IDepartmentService
    {
        DeparmentServiceResult GetDepartments();
        Task<DeparmentServiceResult> SaveDeparment(Models.DeparmentModel deparment);

        Task<DeparmentServiceResult> UpdateDeparment(Models.DeparmentModel deparment);

        Task<DeparmentServiceResult> GetDeparmentById(int Id);

    }
}
