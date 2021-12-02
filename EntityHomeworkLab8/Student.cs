using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDb
{
    public class Student
    {
        public int StudentID { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public DateTime Birthday { get; private set; }
        public int Bursary { get; private set; }
        public int? Bonus { get; private set; }
        public int? CityID { get; private set; }
        public int GroupID { get; private set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
        [ForeignKey("GroupID")]
        public Group Group { get; set; }
        public List<StudentSubject> StudentSubject { get; set; }
    }
}
