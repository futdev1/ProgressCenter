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
        /// <summary>
        /// service management for adding data to the database
        /// </summary>
        /// <param name="adminDto"></param>
        /// <returns></returns>
        Task<BaseResponse<Admin>> CreateAsync(AdminForCreationDto adminDto);

        /// <summary>
        /// management department for database retrieval services
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<BaseResponse<Admin>> GetAsync(Expression<Func<Admin, bool>> expression);

        /// <summary>
        /// this service manages the work for the get all method
        /// that is, from the base
        /// </summary>
        /// <param name="params"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        BaseResponse<IEnumerable<Admin>> GetAll(PaginationParams @params, Expression<Func<Admin, bool>> expression = null);

        /// <summary>
        /// service management for deleting data from the database
        /// management department for database retrieval services
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Admin, bool>> expression);

        /// <summary>
        /// service management department to change the information in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminDto"></param>
        /// <returns></returns>
        Task<BaseResponse<Admin>> UpdateAsync(long id, AdminForCreationDto adminDto);

        /// <summary>
        /// services management department to receive information related to the byte category
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}
