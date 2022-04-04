using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Students;
using ProgressCenter.Service.DTOs.Students;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Service.Interfaces
{
    public interface IStudentService
    {
        Task<BaseResponse<Student>> CreateAsync(StudentForCreationDto StudentDto);
        Task<BaseResponse<Student>> GetAsync(Expression<Func<Student, bool>> expression);
        BaseResponse<IEnumerable<Student>> GetAll(PaginationParams @params, Expression<Func<Student, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Student, bool>> expression);
        Task<BaseResponse<Student>> UpdateAsync(long id, StudentForCreationDto StudentDto);

        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}
