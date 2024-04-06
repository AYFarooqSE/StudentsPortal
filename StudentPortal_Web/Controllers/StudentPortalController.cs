using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentPortal_Web.Models;
using StudentPortal_Web.Models.Dto;
using StudentPortal_Web.Services.IService;
namespace StudentPortal_Web.Controllers
{
    public class StudentPortalController : Controller
    {
        private IStudentService _serviceRepo;
        private IMapper _mapper;
        public StudentPortalController(IStudentService serviceRepo,IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _mapper= mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<StudentsDto> Stdlist=new List<StudentsDto>();
            var Response = await _serviceRepo.GetAllAsync<ApiResponse>();
            if(Response!=null && Response.IsSuccess)
            {
                Stdlist = JsonConvert.DeserializeObject<List<StudentsDto>>(Convert.ToString(Response.Result));
            }
            return View();
        }
    }
}
