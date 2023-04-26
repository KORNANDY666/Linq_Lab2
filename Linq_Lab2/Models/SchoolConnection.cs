using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Linq_Lab2.Models
{
    public class SchoolConnection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolConnectionId { get; set; }

        [ForeignKey("Teachers")]
        public int FK_TeacherId { get; set; }
        public virtual Teacher Teachers { get; set; } = default!;

        [ForeignKey("Students")]
        public int FK_StudentId { get; set; }
        public virtual Student Students { get; set; } = default!;

        [ForeignKey("Courses")]
        public int FK_CourseId { get; set; }
        public virtual Course Courses { get; set; } = default!;

        [ForeignKey("SchoolClasses")]
        public int FK_SchoolClassId{ get; set; }
        public virtual SchoolClass SchoolClasses { get; set; } = default!;
    }
}
