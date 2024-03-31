using AutoMapper;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsPortal_API.Data;
using StudentsPortal_API.Model;
using StudentsPortal_API.Model.Dto;
using System.Reflection.Metadata.Ecma335;

namespace StudentsPortal_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/StudentsPortal")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private ApplicationContext _context;
        private IMapper _mapper;
        public StudentsController(ApplicationContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentsDto>> GetStudents()
        {
            var StudentLists = _context.Tbl_StudentsBasicInfo.ToList();
            
            // _mapper.Map<Destination>(Source)

            return Ok(_mapper.Map<List<StudentsDto>>(StudentLists));
        }

        [HttpGet("ID")]
        public ActionResult<StudentsDto> GetStudents(int? StudentID)
        {
            var model = _context.Tbl_StudentsBasicInfo.Where(x => x.ID == StudentID).FirstOrDefault();

            return Ok(_mapper.Map<StudentsDto>(model));
        }

        [HttpPost]
        public ActionResult CreateNew(StudentCreateDto model)
        {
            if (model == null)
            {
                return NotFound();
            }
            var Stdmodel = _mapper.Map<StudentsModel>(model);

            _context.Tbl_StudentsBasicInfo.Add(Stdmodel);
            _context.SaveChanges();

            //return CreatedAtRoute("GetStudents", new { ID = model.ID }, model);
            return Ok(Stdmodel);
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
        public IActionResult UpdateData([FromBody] StudentUpdateDto model, [FromRoute] int? ID)
        {

            var StdDb = _context.Tbl_StudentsBasicInfo.Where(x => x.ID == ID).FirstOrDefault();
            // Sometime it tracks previous IDs while Using FirstOrDefault
            //var ModelToUpdate = _context.Tbl_StudentsBasicInfo.AsNoTracking().Where(x => x.ID == ID).FirstOrDefault();

            if (StdDb == null)
            {
                return NotFound();
            }

            var ModelToUpdate = _mapper.Map<StudentsModel>(model);



            _context.Tbl_StudentsBasicInfo.Update(ModelToUpdate);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
