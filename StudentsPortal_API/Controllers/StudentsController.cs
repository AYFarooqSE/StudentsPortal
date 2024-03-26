using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsPortal_API.Model;
using StudentsPortal_API.Model.Dto;

namespace StudentsPortal_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/StudentsPortal")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<StudentsDto> GetStudents()
        {
            List<StudentsDto> listd = new List<StudentsDto>()
            {
                new StudentsDto(){ID=101,FirstName="F Name",LastName="L Name",Age=28,Username="demo",Password="123",Address="Address",City="City",Email="demo@gmail.com",FatherName="Father Name",IsDisabled=false },
                new StudentsDto(){ID=102,FirstName="F Name",LastName="L Name",Age=28,Username="demo",Password="123",Address="Address",City="City",Email="demo@gmail.com",FatherName="Father Name",IsDisabled=false },
                new StudentsDto(){ID=103,FirstName="F Name",LastName="L Name",Age=28,Username="demo",Password="123",Address="Address",City="City",Email="demo@gmail.com",FatherName="Father Name",IsDisabled=false }

            };

            return listd;
        }

        [HttpGet("ID")]
        public StudentsDto GetStudentByID(int ID)
        {
            List<StudentsDto> listd = new List<StudentsDto>()
            {
                new StudentsDto(){ID=101,FirstName="F Name",LastName="L Name",Age=28,Username="demo",Password="123",Address="Address",City="City",Email="demo@gmail.com",FatherName="Father Name",IsDisabled=false },
                new StudentsDto(){ID=102,FirstName="F Name",LastName="L Name",Age=28,Username="demo",Password="123",Address="Address",City="City",Email="demo@gmail.com",FatherName="Father Name",IsDisabled=false },
                new StudentsDto(){ID=103,FirstName="F Name",LastName="L Name",Age=28,Username="demo",Password="123",Address="Address",City="City",Email="demo@gmail.com",FatherName="Father Name",IsDisabled=false }

            };
            return listd.Where(x => x.ID == ID).FirstOrDefault(); 
        }
    }
}
