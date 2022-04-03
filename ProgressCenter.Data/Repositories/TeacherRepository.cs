using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Entities.Teachers;

namespace ProgressCenter.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ProgressCenterDbContext dbContext) : base(dbContext) { }
    }
}
