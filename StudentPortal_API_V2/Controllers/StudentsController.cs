using AutoMapper;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal_API_V2.Repository.IRepository;
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
        private IStudentRepository _students;
        private IMapper _mapper;
        public StudentsController(IStudentRepository students, IMapper mapper)
        {
            _mapper= mapper;
            _students = students;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<StudentsDto>>> GetStudents()
        {
            var modelDb = await _students.GetAll();
            return Ok(_mapper.Map<List<StudentsDto>>(modelDb));
        }

        [HttpGet("ID")]
        public async Task<ActionResult<StudentsDto>> GetStudents(int? StudentID)
        {
            var model = await _students.Get(x=>x.ID==StudentID);
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
            await _students.Create(Stdmodel);

            //return CreatedAtRoute("GetStudents", new { ID = Stdmodel.ID }, Stdmodel);
            return Ok(Stdmodel);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _students.Get(x => x.ID == id);
            
            await _students.Delete(model);
            
            return NoContent();
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

            await _students.UpdateRecord(ModelToUpdate);

            return NoContent();
        }
    }
}
