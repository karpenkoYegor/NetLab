using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDb
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }
        [Required]
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UniversityID { get; set; }
        public List<Student> Student { get; set; }

        public University University { get; set; }
    }
}