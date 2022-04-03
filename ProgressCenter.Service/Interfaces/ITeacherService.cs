using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Teachers;
using ProgressCenter.Service.DTOs.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Service.Interfaces
{
    public interface ITeacherService
    {
        Task<BaseResponse<Teacher>> CreateAsync(TeacherForCreationDto TeacherDto);
        Task<BaseResponse<Teacher>> GetAsync(Expression<Func<Teacher, bool>> expression);
        Task<BaseResponse<IEnumerable<Teacher>>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Teacher, bool>> expression);
        Task<BaseResponse<Teacher>> UpdateAsync(long id, TeacherForCreationDto TeacherDto);
    }
}
