using AutoMapper;
using StudentsPortal_API.Model;
using StudentsPortal_API.Model.Dto;

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
