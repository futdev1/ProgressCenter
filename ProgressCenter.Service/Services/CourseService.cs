using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Admins;
using ProgressCenter.Domain.Entities.Courses;
using ProgressCenter.Domain.Enums;
using ProgressCenter.Service.DTOs.Courses;
using ProgressCenter.Service.Extensions;
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

        public async Task<BaseResponse<Course>> CreateAsync(CourseForCreationDto courseDto)
        {
            var response = new BaseResponse<Course>();

            var existCourse = await unitOfWork.Courses.GetAsync(p => p.Name == courseDto.Name);
            if (existCourse is not null)
            {
                response.Error = new ErrorResponse(400, "User is exist");
                return response;
            }

            var mappedCourse = mapper.Map<Course>(courseDto);

            var result = await unitOfWork.Courses.CreateAsync(mappedCourse);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist student
            var existCourse = await unitOfWork.Courses.GetAsync(expression);
            if (existCourse is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existCourse.Delete();

            var result = unitOfWork.Courses.UpdateAsync(existCourse);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public BaseResponse<IEnumerable<Course>> GetAll(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<Course>>();

            IEnumerable<Course> course = unitOfWork.Courses.GetAll(expression);

            response.Data = course.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression)
        {
            var response = new BaseResponse<Course>();

            var student = await unitOfWork.Courses.GetAsync(expression);
            if (student is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = student;

            return response;
        }

        public async Task<BaseResponse<Course>> UpdateAsync(long id, CourseForCreationDto CourseDto)
        {
            var response = new BaseResponse<Course>();

            // check for exist student
            var course = await unitOfWork.Courses.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (course is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            course.Name = CourseDto.Name;

            course.PeriodOfDuration = CourseDto.PeriodOfDuration;

            var result = unitOfWork.Courses.UpdateAsync(course);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
