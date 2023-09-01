using Microsoft.AspNetCore.Identity;

namespace school_helper.Entities
{
    public class Assignment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }

    }
}
