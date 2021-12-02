using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDb
{
    public class Teacher
    {
        public int TeacherID { get; private set; }
        [Required]
        public string Name { get; private set; }
        public int Phone { get; private set; }
        public int SubjectID { get; private set; }
        [ForeignKey("SubjectID")]
        public Subject Subject { get; set; }
        public List<UniversityTeacher> UniversityTeacher { get; set; }
    }
}
