using System;
using System.Collections.Generic;
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
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Interests { get; set; }
        public List<string> Needs { get; set; }
    }
}