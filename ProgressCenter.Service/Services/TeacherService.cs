using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Teachers;
using ProgressCenter.Domain.Enums;
using ProgressCenter.Service.DTOs.Teachers;
using ProgressCenter.Service.Extensions;
using ProgressCenter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }

        public async Task<BaseResponse<Teacher>> CreateAsync(TeacherForCreationDto teacherDto)
        {
            var response = new BaseResponse<Teacher>();

            var existTeacher = await unitOfWork.Teachers.GetAsync(p => p.Login == teacherDto.Login);
            if (existTeacher is not null)
            {
                response.Error = new ErrorResponse(400, "User is exist");
                return response;
            }

            var mappedTeacher = mapper.Map<Teacher>(teacherDto);

            mappedTeacher.Image = await SaveFileAsync(teacherDto.Image.OpenReadStream(), teacherDto.Image.FileName);

            var result = await unitOfWork.Teachers.CreateAsync(mappedTeacher);

            result.Image = "https://localhost:5001/Images/" + result.Image;

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Teacher, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist teacher
            var existTeacher = await unitOfWork.Teachers.GetAsync(expression);
            if (existTeacher is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existTeacher.Delete();

            var result = unitOfWork.Teachers.UpdateAsync(existTeacher);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Teacher>>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<Teacher>>();

            IEnumerable<Teacher> teachers = unitOfWork.Teachers.GetAll(expression);

            response.Data = teachers.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Teacher>> GetAsync(Expression<Func<Teacher, bool>> expression)
        {
            var response = new BaseResponse<Teacher>();

            var teacher = await unitOfWork.Teachers.GetAsync(expression);
            if (teacher is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = teacher;

            return response;
        }

        public async Task<BaseResponse<Teacher>> UpdateAsync(long id, TeacherForCreationDto teacherDto)
        {
            var response = new BaseResponse<Teacher>();

            var teacher = await unitOfWork.Teachers.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (teacher is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            teacher.FirstName = teacherDto.FirstName;
            teacher.LastName = teacherDto.LastName;
            teacher.PhoneNumber = teacherDto.PhoneNumber;
            teacher.Email = teacherDto.Email;
            teacher.Login = teacherDto.Login;
            teacher.Password = teacherDto.Password;
            teacher.DateOfBirth = teacherDto.DateOfBirth;

            var result = unitOfWork.Teachers.UpdateAsync(teacher);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<string> SaveFileAsync(Stream file, string fileName)
        {
            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;
            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream mainFile = File.Create(filePath);
            await file.CopyToAsync(mainFile);
            mainFile.Close();

            return fileName;
        }
    }
}
