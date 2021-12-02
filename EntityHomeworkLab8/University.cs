using System.ComponentModel.DataAnnotations;

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
    }
}