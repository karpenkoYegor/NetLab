using System.ComponentModel.DataAnnotations;

namespace UniversityDb
{
    public class Teacher
    {
        public int TeacherID { get; private set; }
        [Required]
        public string Name { get; private set; }
        public int Number { get; private set; }
        public int SubjectID { get; private set; }
    }
}
