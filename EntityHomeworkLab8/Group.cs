using System.ComponentModel.DataAnnotations;

namespace UniversityDb
{
    public class Group
    {
        public int GroupID { get; private set; }
        [Required]
        public string Name { get; private set; }
        public int UniversityID { get; private set; }
    }
}