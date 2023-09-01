using Microsoft.AspNetCore.Identity;

namespace school_helper.DTOs
{
    public class AssignmentDTO
    {
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }

        public string UserId { get; set; }
    }
}
