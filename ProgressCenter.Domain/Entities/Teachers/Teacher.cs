using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Enums;
using System;

namespace ProgressCenter.Domain.Entities.Teachers
{
    public class Teacher : IAuditable
    {
        public Int64 Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String Email { get; set; }

        public byte[] Image { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Int64? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}
