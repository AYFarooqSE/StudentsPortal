using Microsoft.EntityFrameworkCore;
using StudentPortal_API_V2.Repository.IRepository;
using StudentsPortal_API.Data;
using System.Linq.Expressions;

namespace StudentPortal_API_V2.Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        private readonly ApplicationContext _db;
        internal DbSet<T> _context;
        public RepositoryGeneric(ApplicationContext db)
        {
            _db = db;
            _context=_db.Set<T>();
        }
        public async Task Create(T model)
        {
            await _context.AddAsync(model);
            await Save();
        }

        public async Task Delete(T model)
        {
            _context.Remove(model);
            await Save();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, bool Include = true)
        {
            IQueryable<T> query = _context;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _context;
            if (filter != null)
            {
                query.Where(filter);
            }
            return await _context.ToListAsync();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
