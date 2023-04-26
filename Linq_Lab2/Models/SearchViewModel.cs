using System.ComponentModel;

namespace Linq_Lab2.Models
{
    public class SearchViewModel
    {
        public int Id { get; set; }
        [DisplayName("Teachers First Name")]
        public string TFirstName { get; set; }
        [DisplayName("Teachers Last Name")]
        public string TLastName { get; set; }
        [DisplayName("Students First Name")]
        public string SFirstName { get; set; }
        [DisplayName("Students Last Name")]
        public string SLastName { get; set; }
        [DisplayName("Corses")]
        public string Course { get; set; }
        [DisplayName("Class")]
        public string SchoolClass{ get; set; }
    }
}
