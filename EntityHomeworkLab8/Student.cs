using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDb
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public int Bursary { get; set; }
        public int? Bonus { get; set; }

        public int? CityID { get; set; }

        public int GroupID { get; set; }

        public City City { get; set; }

        public Group Group { get; set; }
        public List<StudentSubject> StudentSubject { get; set; }
    }
}
