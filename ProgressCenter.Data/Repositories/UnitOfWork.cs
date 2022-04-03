using Microsoft.Extensions.Configuration;
using ProgressCenter.Data.Contexts;
using ProgressCenter.Data.IRepositories;
using Serilog;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace ProgressCenter.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgressCenterDbContext dbContext;
        private readonly IConfiguration config;
        private readonly ILogger logger;

        /// <summary>
        /// Repositories
        /// </summary>
        public IAdminRepository Admins { get; private set; }

        public ICourseRepository Courses { get; private set; }

        public IGroupRepository Groups { get; private set; }

        public IStudentRepository Students { get; private set; }

        public ITeacherRepository Teachers { get; private set; }

        public UnitOfWork(ProgressCenterDbContext dbContext, IConfiguration config)
        {
            this.dbContext = dbContext;
            this.config = config;
            this.logger = new LoggerConfiguration()
                .WriteTo.File
                (
                    path: "Logs/logs.txt",
                    outputTemplate: config.GetSection("Serilog:OutputTemlate").Value,
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information
                ).CreateLogger();

            Admins = new AdminRepository(dbContext, logger);
            
            Courses = new CourseRepository(dbContext, logger);
            
            Groups = new GroupRepository(dbContext, logger);
            
            Students = new StudentRepository(dbContext, logger);
            
            Teachers = new TeacherRepository(dbContext, logger);
        }
            
        public void Dispose()
        {
            GC.SuppressFinalize(this);  
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
