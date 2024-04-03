using AutoMapper;
using StudentPortal_Web.Models;
using StudentPortal_Web.Models.Dto;

namespace StudentPortal_API_V2
{
    public class MappingsConfig:Profile
    {
        public MappingsConfig()
        {
            CreateMap<StudentsModel,StudentsDto>();
            CreateMap<StudentsModel,StudentsDto>().ReverseMap();

            CreateMap<StudentsModel, StudentCreateDto>();
            CreateMap<StudentsModel, StudentCreateDto>().ReverseMap();

            CreateMap<StudentsModel, StudentUpdateDto>();
            CreateMap<StudentsModel, StudentUpdateDto>().ReverseMap();
        }
    }
}
