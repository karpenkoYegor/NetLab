using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniversityDb
{
    public class UniversityTeacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeacherID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UniversityID { get; set; }
        public int Wage { get; set; }

        public Teacher Teacher { get; set; }

        public University University { get; set; }
    }
}
