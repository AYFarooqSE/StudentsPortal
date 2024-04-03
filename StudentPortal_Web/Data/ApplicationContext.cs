using Microsoft.EntityFrameworkCore;
using StudentPortal_Web.Models;

namespace StudentsPortal_Web.Models
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
