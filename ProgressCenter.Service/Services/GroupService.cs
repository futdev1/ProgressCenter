using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Courses;
using ProgressCenter.Domain.Enums;
using ProgressCenter.Service.DTOs.Groups;
using ProgressCenter.Service.Extensions;
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

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<GroupModel.Group, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist student
            var existGroup = unitOfWork.Groups.GetAsync(expression);
            if (existGroup is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            var result = unitOfWork.Groups.UpdateAsync(await existGroup);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public BaseResponse<IEnumerable<GroupModel.Group>> GetAll(PaginationParams @params, Expression<Func<Group, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<GroupModel.Group>>();

            IEnumerable<GroupModel.Group> group = unitOfWork.Groups.GetAll();

            response.Data = group.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<GroupModel.Group>> GetAsync(Expression<Func<GroupModel.Group, bool>> expression)
        {
            var response = new BaseResponse<GroupModel.Group>();

            var group = await unitOfWork.Groups.GetAsync(expression);
            if (group is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = group;

            return response;
        }

        public async Task<BaseResponse<GroupModel.Group>> UpdateAsync(long id, GroupForCreationDto groupDto)
        {
            var response = new BaseResponse<GroupModel.Group>();

            // check for exist student
            var group = await unitOfWork.Groups.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (group is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            group.Name = groupDto.Name;
            group.NumberOfStudent = groupDto.NumberOfStudent;
            group.TeacherId = groupDto.TeacherId;

            var result = unitOfWork.Groups.UpdateAsync(group);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
