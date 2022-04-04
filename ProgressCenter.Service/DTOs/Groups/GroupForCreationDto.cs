using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Service.DTOs.Groups
{
    public class GroupForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int NumberOfStudent { get; set; }

        [Required]
        public long CourseId { get; set; }

        [Required]
        public long TeacherId { get; set; }
    }
}
