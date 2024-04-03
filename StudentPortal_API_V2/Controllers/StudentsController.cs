using AutoMapper;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal_API_V2;
using StudentPortal_API_V2.Repository.IRepository;
using StudentsPortal_API.Data;
using StudentsPortal_API.Model;
using StudentsPortal_API.Model.Dto;
using System.Net;

namespace StudentsPortal_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/StudentsPortal")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentRepository _students;
        private IMapper _mapper;
        public ApiResponse _response;
        public StudentsController(IStudentRepository students, IMapper mapper)
        {
            _mapper= mapper;
            _students = students;
            _response = new();
        }

        [HttpGet]
        public async  Task<ActionResult<ApiResponse>> GetStudents()
        {

            var modelDb = await _students.GetAll();
            _response.Result = _mapper.Map<List<StudentsDto>>(modelDb);
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }

        [HttpGet("ID")]
        public async Task<ActionResult<ApiResponse>> GetStudents(int? StudentID)
        {
            var model = await _students.Get(x=>x.ID==StudentID);
            _response.Result = _mapper.Map<StudentsDto>(model);
            _response.StatusCode=HttpStatusCode.OK;

            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateNew(StudentCreateDto model)
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
            _response.Result = model;
            _response.StatusCode=HttpStatusCode.NoContent;
            return Ok(_response);
        }
        [HttpPut]
        [Route("{ID:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateData([FromBody] StudentUpdateDto modelDto, [FromRoute] int? ID)
        {
            if(modelDto==null||ID!=modelDto.ID)
            {
                return NotFound();
            }
            var ModelToUpdate = _mapper.Map<StudentsModel>(modelDto);

            await _students.UpdateRecord(ModelToUpdate);
            _response.Result=ModelToUpdate;
            _response.StatusCode=HttpStatusCode.NoContent;

            return Ok(_response);
        }
    }
}
