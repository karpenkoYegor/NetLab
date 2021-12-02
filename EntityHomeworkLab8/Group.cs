using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDb
{
    public class Group
    {
        public int GroupID { get; private set; }
        [Required]
        public string Name { get; private set; }
        public int UniversityID { get; private set; }
        public List<Student> Student { get; set; }
        [ForeignKey("UniversityID")]
        public University University { get; set; }
    }
}