using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProgressCenter.Service.DTOs.Admins
{
    public class AdminForCreationDto
    {
        [Required]
        public String FirstName { get; set; }
        
        [Required]
        public String LastName { get; set; }

        [Required]
        public String PhoneNumber { get; set; }

        [Required]
        public String CardNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public String Email { get; set; }
        
        [Required]
        public String Login { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
