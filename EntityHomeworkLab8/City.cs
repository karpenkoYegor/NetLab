using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityDb
{
    public class City
    {
        public int CityID { get; private set; }
        [Required]
        public string Name { get; private set; }
        public int Population { get; private set; }
        public List<University> University { get; set; }
        public List<Student> Student { get; set; }
    }
}