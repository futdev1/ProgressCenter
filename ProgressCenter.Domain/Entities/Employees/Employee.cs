using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Enums;
using System;

namespace ProgressCenter.Domain.Entities.Employees
{
    public class Employee : IAuditable
    {
        public Int64 Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        /// <summary>
        /// worker position
        /// </summary>
        public String Duty { get; set; }

        public String PhoneNumber { get; set; }

        public String CardNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Int64? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}
