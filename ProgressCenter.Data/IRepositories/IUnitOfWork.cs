using System;
using System.Threading.Tasks;

namespace ProgressCenter.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }

        ICourseRepository Courses { get; }

        IGroupRepository Groups { get; }

        IStudentRepository Students { get; }

        ITeacherRepository Teachers { get; }

        Task SaveChangesAsync();
    }
}
