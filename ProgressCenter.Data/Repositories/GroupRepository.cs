using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using Serilog;

namespace ProgressCenter.Data.Repositories
{
    public class GroupRepository : GenericRepository<ProgressCenter.Domain.Entities.Groups.Group>, IGroupRepository
    {
        public GroupRepository(ProgressCenterDbContext dbCnotext, ILogger logger) : base(dbCnotext, logger) { }
    }
}
