using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Teachers;
using ProgressCenter.Domain.Enums;
using ProgressCenter.Service.DTOs.Teachers;
using ProgressCenter.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgressCenter.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService teacherService;
        private readonly IWebHostEnvironment env;

        public TeachersController(ITeacherService teacherService, IWebHostEnvironment env)
        {
            this.teacherService = teacherService;
            this.env = env;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Teacher>>> Create([FromForm] TeacherForCreationDto TeacherDto)
        {
            var result = await teacherService.CreateAsync(TeacherDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Teacher>>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await teacherService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Teacher>>> Get([FromRoute] long id)
        {
            var result = await teacherService.GetAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Teacher>>> Update(long id, TeacherForCreationDto TeacherDto)
        {
            var result = await teacherService.UpdateAsync(id, TeacherDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(long id)
        {
            var result = await teacherService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

    }
}
