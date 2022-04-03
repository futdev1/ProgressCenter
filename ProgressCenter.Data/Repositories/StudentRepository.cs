using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Domain.Entities.Students;

namespace ProgressCenter.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ProgressCenterDbContext dbContext) : base(dbContext) { }
    }
}
