using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressCenter.Service.DTOs.Groups
{
    public class GroupForCreationDto
    {
        public string Name { get; set; }

        public int NumberOfStudent { get; set; }

        public long CourseId { get; set; }

        public long TeacherId { get; set; }
    }
}
