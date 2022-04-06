using AutoMapper;
using ProgressCenter.Domain.Entities.Admins;
using ProgressCenter.Domain.Entities.Courses;
using ProgressCenter.Domain.Entities.Students;
using ProgressCenter.Domain.Entities.Teachers;
using ProgressCenter.Service.DTOs.Admins;
using ProgressCenter.Service.DTOs.Courses;
using ProgressCenter.Service.DTOs.Groups;
using ProgressCenter.Service.DTOs.Students;
using ProgressCenter.Service.DTOs.Teachers;

namespace ProgressCenter.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdminForCreationDto, Admin>().ReverseMap();
            CreateMap<GroupForCreationDto, ProgressCenter.Domain.Entities.Groups.Group>().ReverseMap();
            CreateMap<StudentForCreationDto, Student>().ReverseMap();
            CreateMap<TeacherForCreationDto, Teacher>().ReverseMap();
            CreateMap<CourseForCreationDto, Course>().ReverseMap();
        }
    }
}
