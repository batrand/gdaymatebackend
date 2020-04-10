using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDayMateBackend.Data
{
    public class Location
    {
        [Key]
        [Required]
        public long Id { get; set; }

        public string Name { get; set; }

        public int PostCode { get; set; }

        [ForeignKey(nameof(Country))]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}