using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsPortal_API.Data;
using StudentsPortal_API.Model;
using StudentsPortal_API.Model.Dto;

namespace StudentsPortal_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/StudentsPortal")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private ApplicationContext _context;
        public StudentsController(ApplicationContext context)
        {

            _context = context;

        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<StudentsDto>>> GetStudents()
        {
            return Ok( await _context.Tbl_StudentsBasicInfo.ToListAsync());
        }

        [HttpGet("ID")]
        public async Task<ActionResult<StudentsModel>> GetStudents(int? StudentID)
        {
            var model = await _context.Tbl_StudentsBasicInfo.Where(x => x.ID == StudentID).FirstOrDefaultAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNew(StudentCreateDto model)
        {
            if (model == null)
            {
                return NotFound();
            }

            StudentsModel Stdmodel = new StudentsModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password,
                Address = model.Address,
                City = model.City,
                FatherName = model.FatherName,
                Age = model.Age,
                Email = model.Email,
                CreatedAt = DateTime.Now,
                IsDisabled = false
            };

            _context.Tbl_StudentsBasicInfo.Add(Stdmodel);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetStudents", new { ID = Stdmodel.ID }, Stdmodel);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var modelToDelete = _context.Tbl_StudentsBasicInfo.Where(x => x.ID == id).FirstOrDefault();
            if (modelToDelete != null)
            {
                _context.Tbl_StudentsBasicInfo.Remove(modelToDelete); // Remove Don't have async
                 await _context.SaveChangesAsync();
            }
            return Ok(modelToDelete);
        }
        [HttpPut]
        [Route("{ID:int}")]
        public async Task<IActionResult> UpdateData([FromBody] StudentUpdateDto model, [FromRoute] int? ID)
        {

            var ModelToUpdate = await _context.Tbl_StudentsBasicInfo.Where(x => x.ID == ID).FirstOrDefaultAsync();
            // Sometime it tracks previous IDs while Using FirstOrDefault
            //var ModelToUpdate = _context.Tbl_StudentsBasicInfo.AsNoTracking().Where(x => x.ID == ID).FirstOrDefault();

            if (ModelToUpdate == null)
            {
                return NotFound();
            }

            ModelToUpdate.FirstName = model.FirstName;
            ModelToUpdate.LastName = model.LastName;
            ModelToUpdate.Email = model.Email;
            ModelToUpdate.Address = model.Address;
            ModelToUpdate.City = model.City;
            ModelToUpdate.Age = model.Age;
            ModelToUpdate.FatherName = model.FatherName;
            ModelToUpdate.Username = model.Username;
            ModelToUpdate.Password = model.Password;
            ModelToUpdate.IsDisabled = model.IsDisabled;


            _context.Tbl_StudentsBasicInfo.Update(ModelToUpdate);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
