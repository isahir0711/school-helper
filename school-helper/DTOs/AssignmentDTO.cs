using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace school_helper.DTOs
{
    public class AssignmentDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }

        public string UserId { get; set; }

        [Required]
        public int ClassId { get; set; }
    }
}
