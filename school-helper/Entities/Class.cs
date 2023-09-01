using System.ComponentModel.DataAnnotations;

namespace school_helper.Entities
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public List<int> DaysIds { get; set; }

    }
}
