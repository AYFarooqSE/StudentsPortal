using AutoMapper;
using StudentsPortal_API.Model;
using StudentsPortal_API.Model.Dto;

namespace StudentsPortal_API
{
    public class AutoMapConfigs:Profile
    {
        public AutoMapConfigs()
        {
            CreateMap<StudentsModel,StudentsDto>();
            CreateMap<StudentsDto, StudentsModel>();

            // Creating Reverse Map
            CreateMap<StudentsModel, StudentCreateDto>();
            CreateMap<StudentsModel, StudentCreateDto>().ReverseMap();
            CreateMap<StudentsModel, StudentUpdateDto>();
            CreateMap<StudentsModel, StudentUpdateDto>().ReverseMap();
        }
    }
}
