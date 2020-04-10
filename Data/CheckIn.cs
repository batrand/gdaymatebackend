using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDayMateBackend.Data
{
    public class CheckIn
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public List<int> Responses { get; set; }
    }
}