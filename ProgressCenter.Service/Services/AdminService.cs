using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Admins;
using ProgressCenter.Domain.Enums;
using ProgressCenter.Service.DTOs.Admins;
using ProgressCenter.Service.Extensions;
using ProgressCenter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgressCenter.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;
        
        
        public AdminService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }

        /// <summary>
        /// service management for adding data to the database
        /// </summary>
        /// <param name="adminDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<Admin>> CreateAsync(AdminForCreationDto adminDto)
        {
            BaseResponse<Admin> response = new BaseResponse<Admin>();

            Admin existStudent = await unitOfWork.Admins.GetAsync(p => p.Login == adminDto.Login);
            
            if (existStudent is not null)
            {
                response.Error = new ErrorResponse(400, "User is exist");
                return response;
            }

            Admin mappedAdmin = mapper.Map<Admin>(adminDto);

            mappedAdmin.Image = await SaveFileAsync(adminDto.Image.OpenReadStream(), adminDto.Image.FileName);

            Admin result = await unitOfWork.Admins.CreateAsync(mappedAdmin);

            result.Image = "https://localhost:5001/Images/" + result.Image;

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        /// <summary>
        /// service management for deleting data from the database
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Admin, bool>> expression)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();

            // check for exist student
            Admin existAdmin = await unitOfWork.Admins.GetAsync(expression);
            if (existAdmin is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existAdmin.Delete();

            Admin result = unitOfWork.Admins.UpdateAsync(existAdmin);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }
        
        /// <summary>
        /// this service manages the work for the get all method
        /// that is, from the base
        /// </summary>
        /// <param name="params"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public BaseResponse<IEnumerable<Admin>> GetAll(PaginationParams @params, Expression<Func<Admin, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            BaseResponse<IEnumerable<Admin>> response = new BaseResponse<IEnumerable<Admin>>();

            IEnumerable<Admin> admins = unitOfWork.Admins.GetAll(expression);

            response.Data = admins.ToPagedList(@params);

            return response;
        }

        /// <summary>
        /// management department for database retrieval services
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<BaseResponse<Admin>> GetAsync(Expression<Func<Admin, bool>> expression)
        {
            BaseResponse<Admin> response = new BaseResponse<Admin>();

            Admin admin = await unitOfWork.Admins.GetAsync(expression);
            
            if (admin is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = admin;

            return response;
        }

        /// <summary>
        /// services management department to receive information related to the byte category
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// service management department to change the information in the database
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<Admin>> UpdateAsync(long id, AdminForCreationDto adminDto)
        {
            var response = new BaseResponse<Admin>();

            // check for exist student
            var admin = await unitOfWork.Admins.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (admin is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            admin.FirstName = adminDto.FirstName;
            admin.LastName = adminDto.LastName;
            admin.PhoneNumber = adminDto.PhoneNumber;
            admin.CardNumber = adminDto.CardNumber;
            admin.Email = adminDto.Email;
            admin.Login = adminDto.Login;
            admin.Password = adminDto.Password;
            admin.DateOfBirth = adminDto.DateOfBirth;
            admin.Update();

            var result = unitOfWork.Admins.UpdateAsync(admin);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
