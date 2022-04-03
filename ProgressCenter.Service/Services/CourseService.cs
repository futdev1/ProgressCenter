using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Courses;
using ProgressCenter.Service.DTOs.Courses;
using ProgressCenter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }

        public Task<BaseResponse<Course>> CreateAsync(CourseForCreationDto CourseDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<Course>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Course>> UpdateAsync(long id, CourseForCreationDto CourseDto)
        {
            throw new NotImplementedException();
        }
    }
}
