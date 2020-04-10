using System.ComponentModel.DataAnnotations;

namespace GDayMateBackend.Data
{
    public class Organisation
    {
        [Key]
        [Required]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
    }
}