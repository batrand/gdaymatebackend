using System.ComponentModel.DataAnnotations;

namespace GDayMateBackend.Data
{
    public class Country
    {
        [Key]
        [Required]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}