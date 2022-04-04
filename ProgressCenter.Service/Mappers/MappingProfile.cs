using AutoMapper;
using ProgressCenter.Domain.Entities.Admins;
using ProgressCenter.Domain.Entities.Students;
using ProgressCenter.Service.DTOs.Admins;
using ProgressCenter.Service.DTOs.Groups;
using ProgressCenter.Service.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdminForCreationDto, Admin>().ReverseMap();
            CreateMap<GroupForCreationDto, ProgressCenter.Domain.Entities.Groups.Group>().ReverseMap();
            CreateMap<StudentForCreationDto, Student>().ReverseMap();
        }
    }
}
