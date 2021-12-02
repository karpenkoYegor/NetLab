using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDb
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Population { get; set; }
        public List<University> University { get; set; }
        public List<Student> Student { get; set; }
    }
}