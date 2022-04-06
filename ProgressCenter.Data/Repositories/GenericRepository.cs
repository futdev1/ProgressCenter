using Microsoft.EntityFrameworkCore;
using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using Serilog;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgressCenter.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal readonly ProgressCenterDbContext dbContext;
        internal readonly DbSet<T> dbSet;
        internal readonly ILogger logger;

        public GenericRepository(ProgressCenterDbContext dbContext, ILogger logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.dbSet = dbContext.Set<T>();
        }

        /// <summary>
        /// adds information to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> CreateAsync(T entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }

        /// <summary>
        /// deletes the data in the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<bool> DeteleAsync(Expression<Func<T, bool>> pred)
        {
            var result = await dbSet.FirstOrDefaultAsync(pred);

            if (result == null)
                return false;

            dbSet.Remove(result);

            return true;
        }

        /// <summary>
        /// data from the database brings it all
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> pred = null)
        {
            return pred is null ? dbSet : dbSet.Where(pred);
        }

        /// <summary>
        /// returns data from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(Expression<Func<T, bool>> pred)
        {
            return await dbSet.FirstOrDefaultAsync(pred);
        }

        /// <summary>
        /// change information from the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T UpdateAsync(T entity)
        {
            var entry = dbSet.Update(entity);

            return entry.Entity;
        }
    }
}
