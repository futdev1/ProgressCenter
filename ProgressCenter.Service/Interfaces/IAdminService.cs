using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Domain.Entities.Admins;
using ProgressCenter.Service.DTOs.Admins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgressCenter.Service.Interfaces
{
    public interface IAdminService
    {
        Task<BaseResponse<Admin>> CreateAsync(AdminForCreationDto adminDto);
        Task<BaseResponse<Admin>> GetAsync(Expression<Func<Admin, bool>> expression);
        Task<BaseResponse<IEnumerable<Admin>>> GetAllAsync(PaginationParams @params, Expression<Func<Admin, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Admin, bool>> expression);
        Task<BaseResponse<Admin>> UpdateAsync(long id, AdminForCreationDto adminDto);

        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}
