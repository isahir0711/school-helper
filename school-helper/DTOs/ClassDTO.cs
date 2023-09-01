﻿using System.ComponentModel.DataAnnotations;

namespace school_helper.DTOs
{
    public class ClassDTO
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public string UserId { get; set; }

        public List<ClassScheduleDTO> ClassSchedules { get; set; }
    }
}
