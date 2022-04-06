using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Entities.Admins;
using Serilog;

namespace ProgressCenter.Data.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ProgressCenterDbContext dbContext, ILogger logger) : base(dbContext, logger) { }
    }
}
