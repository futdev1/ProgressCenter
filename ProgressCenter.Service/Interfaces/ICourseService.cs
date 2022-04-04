using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Courses;
using ProgressCenter.Service.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Service.Interfaces
{
    public interface ICourseService
    {
        Task<BaseResponse<Course>> CreateAsync(CourseForCreationDto CourseDto);
        Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression);
        BaseResponse<IEnumerable<Course>> GetAll(PaginationParams @params, Expression<Func<Course, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression);
        Task<BaseResponse<Course>> UpdateAsync(long id, CourseForCreationDto CourseDto);
    }
}
