using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Configurations;
using ProgressCenter.Service.DTOs.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GroupModel = ProgressCenter.Domain.Entities.Groups;

namespace ProgressCenter.Service.Interfaces
{
    public interface IGroupService
    {
        Task<BaseResponse<Group>> CreateAsync(GroupForCreationDto GroupDto);
        Task<BaseResponse<Group>> GetAsync(Expression<Func<GroupModel.Group, bool>> expression);
        Task<BaseResponse<IEnumerable<Group>>> GetAllAsync(PaginationParams @params, Expression<Func<Group, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<GroupModel.Group, bool>> expression);
        Task<BaseResponse<Group>> UpdateAsync(long id, GroupForCreationDto GroupDto);
    }
}
