using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDb
{
    public class University
    {
        public int UniversityID { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string Address { get; private set; }
        public int CityID { get; private set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
        public List<Group> Group { get; set; }
        public List<UniversityTeacher> UniversityTeacher { get; set; }
    }
}