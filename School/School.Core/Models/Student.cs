using School.Core.Models.Enum;

namespace School.Core.Models
{
    public class Student : Person
    {
        public StudentType Type { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
