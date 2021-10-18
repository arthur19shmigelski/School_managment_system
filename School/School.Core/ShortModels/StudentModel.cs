using School.Core.Models.Enum;

namespace School.Core.ShortModels
{
    public class StudentModel : PersonModel
    {
        public int? GroupId { get; set; }
        public StudentGroupModel Group { get; set; }
        public StudentType Type { get; set; }
    }
}