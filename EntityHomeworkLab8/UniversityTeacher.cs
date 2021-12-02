using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniversityDb
{
    public class UniversityTeacher
    {
        public int TeacherID { get; private set; }
        public int UniversityID { get; private set; }
        public int Wage { get; private set; }
        [ForeignKey("TeacherID")]
        public Teacher Teacher { get; set; }
        [ForeignKey("UniversityID")]
        public University University { get; set; }
    }
}
