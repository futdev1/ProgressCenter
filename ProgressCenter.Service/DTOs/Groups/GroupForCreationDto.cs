using System.ComponentModel.DataAnnotations;

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
