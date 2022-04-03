using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Admins;
using ProgressCenter.Service.DTOs.Admins;
using ProgressCenter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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

        public Task<BaseResponse<Admin>> CreateAsync(AdminForCreationDto adminDto)
        {
               
        }

        public Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Admin, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<Admin>>> GetAllAsync(PaginationParams @params, Expression<Func<Admin, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Admin>> GetAsync(Expression<Func<Admin, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFileAsync(Stream file, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Admin>> UpdateAsync(Guid id, AdminForCreationDto adminDto)
        {
            throw new NotImplementedException();
        }
    }
}
