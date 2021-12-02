using Microsoft.EntityFrameworkCore;

namespace UniversityDb
{
    public class UniversityTeacher
    {
        public int TeacherID { get; private set; }
        public int UniversityID { get; private set; }
        public int Wage { get; private set; }
        public Teacher Teacher { get; set; }
        public University University { get; set; }
    }
}
