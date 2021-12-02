using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityDb
{
    public class Subject
    {
        public int SubjectID { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string Duration { get; private set; }
        public List<Teacher> Teacher { get; set; }
        public List<StudentSubject> StudentSubject { get; set; }
    }
}
