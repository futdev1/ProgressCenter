using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Service.DTOs.Courses
{
    public class CourseForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime PeriodOfDuration { get; set; }
    }
}
