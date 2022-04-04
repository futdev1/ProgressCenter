using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Students;
using ProgressCenter.Domain.Enums;
using ProgressCenter.Service.DTOs.Students;
using ProgressCenter.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgressCenter.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IWebHostEnvironment env;

        public StudentsController(IStudentService sroupService, IWebHostEnvironment env)
        {
            this.studentService = sroupService;
            this.env = env;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Student>>> Create([FromForm] StudentForCreationDto StudentDto)
        {
            var result = await studentService.CreateAsync(StudentDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Student>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = studentService.GetAll(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Student>>> Get([FromRoute] long id)
        {
            var result = await studentService.GetAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Student>>> Update(long id, StudentForCreationDto StudentDto)
        {
            var result = await studentService.UpdateAsync(id, StudentDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(long id)
        {
            var result = await studentService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
