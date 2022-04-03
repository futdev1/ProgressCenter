using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgressCenter.Data.IRepositories
{
    public interface IGenericRepository<T> where T : class 
    {
        /// <summary>
        /// adds information to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// change information from the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T UpdateAsync(T entity);

        /// <summary>
        ///  deletes the data in the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        Task<bool> DeteleAsync(Expression<Func<T, bool>> pred);

        /// <summary>
        /// data from the database brings it all
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> pred = null);

        /// <summary>
        /// returns data from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> pred);
    }
}
