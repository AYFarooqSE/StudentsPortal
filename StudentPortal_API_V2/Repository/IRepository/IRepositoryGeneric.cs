using System.Linq.Expressions;

namespace StudentPortal_API_V2.Repository.IRepository
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter, bool Include = true);
        Task Create(T model);
        Task Delete(T model);
        Task Save();
    }
}
