using StudentsPortal_API.Model;
using System.Linq.Expressions;

namespace StudentPortal_API_V2.Repository.IRepository
{
    public interface IStudentRepository:IRepositoryGeneric<StudentsModel>
    {
        Task UpdateRecord(StudentsModel model);
    }
}
