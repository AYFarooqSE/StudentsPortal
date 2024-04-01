using AutoMapper;
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
        private IMapper _mapper;
        public StudentsController(ApplicationContext context,IMapper mapper)
        {
            _mapper= mapper;
            _context = context;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<StudentsDto>>> GetStudents()
        {
            var modelDb = await _context.Tbl_StudentsBasicInfo.ToListAsync();
            return Ok(_mapper.Map<List<StudentsDto>>(modelDb));
        }

        [HttpGet("ID")]
        public async Task<ActionResult<StudentsDto>> GetStudents(int? StudentID)
        {
            var model = await _context.Tbl_StudentsBasicInfo.Where(x => x.ID == StudentID).FirstOrDefaultAsync();
            return Ok(_mapper.Map<StudentsDto>(model));
        }

        [HttpPost]
        public async Task<ActionResult> CreateNew(StudentCreateDto model)
        {
            if (model == null)
            {
                return NotFound();
            }
            var Stdmodel = _mapper.Map<StudentsModel>(model);

            _context.Tbl_StudentsBasicInfo.Add(Stdmodel);
            await _context.SaveChangesAsync();

            //return CreatedAtRoute("GetStudents", new { ID = Stdmodel.ID }, Stdmodel);
            return Ok(Stdmodel);
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
        public async Task<IActionResult> UpdateData([FromBody] StudentUpdateDto modelDto, [FromRoute] int? ID)
        {
            if(modelDto==null||ID!=modelDto.ID)
            {
                return NotFound();
            }
            var ModelToUpdate = _mapper.Map<StudentsModel>(modelDto);

            _context.Tbl_StudentsBasicInfo.Update(ModelToUpdate);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
