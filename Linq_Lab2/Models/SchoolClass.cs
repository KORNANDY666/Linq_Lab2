using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Linq_Lab2.Models
{
    public class SchoolClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolClassId { get; set; } = 0;
        public string StudentClass { get; set; } = default!;
        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; }
    }
}
