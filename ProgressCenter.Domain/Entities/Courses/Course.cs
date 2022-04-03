using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Enums;
using System;

namespace ProgressCenter.Domain.Entities.Courses
{
    public class Course : IAuditable
    {
        public Int64 Id { get; set; }

        public String Name { get; set; }

        public DateTime PeriodOfDuration { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Int64? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}
