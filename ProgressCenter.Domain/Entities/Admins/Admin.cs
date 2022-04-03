using ProgressCenter.Domain.Commons;
using ProgressCenter.Domain.Enums;
using System;

namespace ProgressCenter.Domain.Entities.Admins
{
    public class Admin : IAuditable
    {
        public long Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String PhoneNumber { get; set; }

        public String CardNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String Email { get; set; }

        public String Login { get; set; }

        public String Password { get; set; }

        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        
        public long? UpdatedBy { get; set; }
        
        public ItemState State { get; set; }
    }
}
