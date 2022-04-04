using Microsoft.Extensions.DependencyInjection;
using ProgressCenter.Data.IRepositories;
using ProgressCenter.Data.Repositories;
using ProgressCenter.Service.Interfaces;
using ProgressCenter.Service.Services;

namespace ProgressCenter.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ITeacherService, TeacherService>();
        }
    }
}
