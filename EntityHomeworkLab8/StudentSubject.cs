using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniversityDb
{
    public class StudentSubject
    {
        public int StudentID { get; private set; }

        public int SubjectID { get; private set; }
        
        public int Mark { get; private set; }
        [ForeignKey("StudentID")]
        public Student Student { get; set; }
        [ForeignKey("SubjectID")]
        public Subject Subject { get; set; }
    }
}
