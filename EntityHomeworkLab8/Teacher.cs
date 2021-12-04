using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDb
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeacherID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Phone { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }

        public Subject Subject { get; set; }
        public List<UniversityTeacher> UniversityTeacher { get; set; }
    }
}
