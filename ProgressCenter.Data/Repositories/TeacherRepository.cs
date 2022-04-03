using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Entities.Teachers;
using Serilog;

namespace ProgressCenter.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ProgressCenterDbContext dbContext, ILogger logger) : base(dbContext, logger) { }
    }
}
