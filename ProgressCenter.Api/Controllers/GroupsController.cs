using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Enums;
using ProgressCenter.Service.DTOs.Groups;
using ProgressCenter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GroupModel = ProgressCenter.Domain.Entities.Groups;

namespace ProgressCenter.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;
        private readonly IWebHostEnvironment env;

        public GroupsController(IGroupService groupService, IWebHostEnvironment env)
        {
            this.groupService = groupService;
            this.env = env;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<ProgressCenter.Domain.Entities.Groups.Group>>> Create([FromForm] GroupForCreationDto courseDto)
        {
            var result = await groupService.CreateAsync(courseDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<GroupModel.Group>>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await groupService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<GroupModel.Group>>> Get([FromRoute] long id)
        {
            var result = await groupService.GetAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<GroupModel.Group>>> Update(long id, GroupForCreationDto CourseDto)
        {
            var result = await groupService.UpdateAsync(id, CourseDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(long id)
        {
            var result = await groupService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
