using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Entities.Courses;

namespace ProgressCenter.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository 
    {
        public CourseRepository(ProgressCenterDbContext dbContext) : base(dbContext) { }
    }
}
