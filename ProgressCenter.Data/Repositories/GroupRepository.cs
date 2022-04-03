using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using System.Text.RegularExpressions;

namespace ProgressCenter.Data.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(ProgressCenterDbContext dbCnotext) : base(dbCnotext) { }
    }
}
