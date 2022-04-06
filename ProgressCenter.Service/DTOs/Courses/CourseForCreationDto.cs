using System.ComponentModel.DataAnnotations;

namespace ProgressCenter.Service.DTOs.Courses
{
    public class CourseForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PeriodOfDuration { get; set; }
    }
}
