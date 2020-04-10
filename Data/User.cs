using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDayMateBackend.Data
{
    public class User
    {
        [Key]
        [Required]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset Birthdate { get; set; }

        [ForeignKey(nameof(Location))]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}