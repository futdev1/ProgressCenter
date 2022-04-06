using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Entities.Courses;
using Serilog;

namespace ProgressCenter.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ProgressCenterDbContext dbContext, ILogger logger) : base(dbContext, logger) { }
    }
}
