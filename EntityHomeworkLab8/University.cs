using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityDb
{
    public class University
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UniversityID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityID { get; set; }

        public City City { get; set; }
        public List<Group> Group { get; set; }
        public List<UniversityTeacher> UniversityTeacher { get; set; }
    }
}