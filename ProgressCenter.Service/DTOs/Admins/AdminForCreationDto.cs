using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProgressCenter.Service.DTOs.Admins
{
    public class AdminForCreationDto
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public IFormFile Image { get; set; }
    }
}
