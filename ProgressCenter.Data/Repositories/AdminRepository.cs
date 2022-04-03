using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Entities.Admins;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Data.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ProgressCenterDbContext dbContext, ILogger logger) : base(dbContext, logger) { }
    }
}
