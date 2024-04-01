using Microsoft.EntityFrameworkCore;
using StudentPortal_API_V2.Repository.IRepository;
using StudentsPortal_API.Data;
using StudentsPortal_API.Model;
using System.Linq.Expressions;

namespace StudentPortal_API_V2.Repository
{
    public class StudentRepository : RepositoryGeneric<StudentsModel>, IStudentRepository
    {

        private readonly ApplicationContext _db;
        public StudentRepository(ApplicationContext db):base(db)
        {
            _db = db;
        }
        public async Task UpdateRecord(StudentsModel model)
        {
            _db.Tbl_StudentsBasicInfo.Update(model);
            await _db.SaveChangesAsync();
        }
    }
}
