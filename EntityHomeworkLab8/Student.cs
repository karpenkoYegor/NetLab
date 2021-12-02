﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public City City { get; set; }
        public Group Group { get; set; }
        public List<StudentSubject> StudentSubject { get; set; }
    }
}
