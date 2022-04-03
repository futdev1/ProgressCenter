﻿using Microsoft.EntityFrameworkCore;
using ProgressCenter.Domain.Entities.Courses;
using ProgressCenter.Domain.Entities.Employees;
using ProgressCenter.Domain.Entities.Students;
using ProgressCenter.Domain.Entities.Teachers;
using System.Text.RegularExpressions;

namespace ProgressCenter.Data.Contexts
{
    public class ProgressCenterDbContext : DbContext
    {
        public ProgressCenterDbContext(DbContextOptions<ProgressCenterDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
