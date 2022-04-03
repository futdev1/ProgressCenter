using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Courses;
using ProgressCenter.Domain.Enums;
using ProgressCenter.Service.DTOs.Courses;
using ProgressCenter.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgressCenter.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly IWebHostEnvironment env;
        public CoursesController(ICourseService courseService, IWebHostEnvironment env)
        {
            this.courseService = courseService;
            this.env = env;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Course>>> Create([FromForm] CourseForCreationDto courseDto)
        {
            var result = await courseService.CreateAsync(courseDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Course>>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await courseService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Course>>> Get([FromRoute] long id)
        {
            var result = await courseService.GetAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Course>>> Update(long id, CourseForCreationDto CourseDto)
        {
            var result = await courseService.UpdateAsync(id, CourseDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(long id)
        {
            var result = await courseService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
