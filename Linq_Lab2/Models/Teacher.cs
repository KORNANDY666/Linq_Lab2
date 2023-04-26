using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Linq_Lab2.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; } = 0;
        [Required]
        [StringLength(30)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = default!;
        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; }

    }
}
