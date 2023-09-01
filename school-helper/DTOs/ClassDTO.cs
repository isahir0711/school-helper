using System.ComponentModel.DataAnnotations;

namespace school_helper.DTOs
{
    public class ClassDTO
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public List<int> DaysIds { get; set; }


        public List<string> DaysNames { get; set; }

        public string UserId { get; set; }
    }
}
