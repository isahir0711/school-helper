using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace school_helper.Entities
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public List<ClassSchedule> ClassSchedules { get; set; }

    }
}
