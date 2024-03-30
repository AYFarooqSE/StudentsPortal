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
        public ActionResult<IEnumerable<StudentsDto>> GetStudents()
        {
            return Ok(_context.Tbl_StudentsBasicInfo.ToList());
        }

        [HttpGet("ID")]
        public ActionResult<StudentsModel> GetStudents(int? StudentID)
        {
            var model = _context.Tbl_StudentsBasicInfo.Where(x => x.ID == StudentID).FirstOrDefault();
            return Ok(model);
        }

        [HttpPost]
        public ActionResult CreateNew(StudentsModel model)
        {
            if (model != null)
            {
                _context.Tbl_StudentsBasicInfo.Add(model);
                _context.SaveChanges();
            }
            return Ok(model);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var modelToDelete = _context.Tbl_StudentsBasicInfo.Where(x => x.ID == id).FirstOrDefault();
            if (modelToDelete != null)
            {
                _context.Tbl_StudentsBasicInfo.Remove(modelToDelete);
                _context.SaveChanges();
            }
            return Ok(modelToDelete);
        }
        [HttpPut]
        [Route("{ID:int}")]
        public IActionResult UpdateData([FromBody] StudentsDto model, [FromRoute] int? ID)
        {

            var ModelToUpdate = _context.Tbl_StudentsBasicInfo.Where(x => x.ID == ID).FirstOrDefault();
            // Sometime it tracks previous IDs while Using FirstOrDefault
            //var ModelToUpdate = _context.Tbl_StudentsBasicInfo.AsNoTracking().Where(x => x.ID == ID).FirstOrDefault();
            
            if (ModelToUpdate==null)
            {
                return NotFound();
            }

            ModelToUpdate.FirstName= model.FirstName;
            ModelToUpdate.LastName= model.LastName;
            ModelToUpdate.Email= model.Email;
            ModelToUpdate.Address= model.Address;
            ModelToUpdate.City= model.City;
            ModelToUpdate.Age= model.Age;
            ModelToUpdate.FatherName= model.FatherName;
            ModelToUpdate.Username= model.Username;
            ModelToUpdate.Password= model.Password;
            ModelToUpdate.IsDisabled= model.IsDisabled;


            _context.Tbl_StudentsBasicInfo.Update(ModelToUpdate);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}
