using AutoMapper;
using school_helper.DTOs;
using school_helper.Entities;

namespace school_helper.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Assignment, AssignmentDTO>().ReverseMap();

            CreateMap<Class, ClassDTO>().ReverseMap();

        }
    }
}
