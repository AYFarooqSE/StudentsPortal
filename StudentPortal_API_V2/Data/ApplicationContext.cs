using Microsoft.EntityFrameworkCore;
using StudentsPortal_API.Model;

namespace StudentsPortal_API.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }

        // Tables
        public DbSet<StudentsModel> Tbl_StudentsBasicInfo { get; set; }
    }
}
