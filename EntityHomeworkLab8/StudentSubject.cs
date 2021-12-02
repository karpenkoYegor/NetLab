using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UniversityDb
{
    public class StudentSubject
    {
        public int StudentID { get; private set; }

        public int SubjectID { get; private set; }
        
        public int Mark { get; private set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
