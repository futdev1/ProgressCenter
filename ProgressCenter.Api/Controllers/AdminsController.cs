using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Admins;
using ProgressCenter.Domain.Enums;
using ProgressCenter.Service.DTOs.Admins;
using ProgressCenter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgressCenter.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService adminService;
        private readonly IWebHostEnvironment env;
        public AdminsController(IAdminService adminService, IWebHostEnvironment env)
        {
            this.adminService = adminService;
            this.env = env;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Admin>>> Create([FromForm] AdminForCreationDto adminDto)
        {
            var result = await adminService.CreateAsync(adminDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Admin>>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await adminService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Admin>>> Get([FromRoute] long id)
        {
            var result = await adminService.GetAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Admin>>> Update(long id, AdminForCreationDto adminDto)
        {
            var result = await adminService.UpdateAsync(id, adminDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(long id)
        {
            var result = await adminService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
