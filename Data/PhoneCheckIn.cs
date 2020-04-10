using System;
using System.ComponentModel.DataAnnotations;

namespace GDayMateBackend.Data
{
    public class PhoneCheckIn
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Responses { get; set; }
    }
}