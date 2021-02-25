using System.Threading.Tasks;
namespace CourseAdmin.Respository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task<bool> Rollback();
    }
}
