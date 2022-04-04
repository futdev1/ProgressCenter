using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Courses;
using ProgressCenter.Service.DTOs.Groups;
using ProgressCenter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GroupModel = ProgressCenter.Domain.Entities.Groups;

namespace ProgressCenter.Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }

        public async Task<BaseResponse<GroupModel.Group>> CreateAsync(GroupForCreationDto groupDto)
        {
            var response = new BaseResponse<GroupModel.Group>();

            var existGroup = await unitOfWork.Courses.GetAsync(p => p.Name == groupDto.Name);
            if (existGroup is not null)
            {
                response.Error = new ErrorResponse(400, "User is exist");
                return response;
            }

            var mappedGroup = mapper.Map<GroupModel.Group>(groupDto);

            var result = await unitOfWork.Groups.CreateAsync(mappedGroup);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public Task<BaseResponse<bool>> DeleteAsync(Expression<Func<GroupModel.Group, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<GroupModel.Group>>> GetAllAsync(PaginationParams @params, Expression<Func<Group, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<GroupModel.Group>> GetAsync(Expression<Func<GroupModel.Group, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Group>> UpdateAsync(long id, GroupForCreationDto GroupDto)
        {
            throw new NotImplementedException();
        }
    }
}
