using School.Core.Models.Enum;
using System.Collections.Generic;

namespace School.Core.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Program { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
        public double? Price { get; set; }
        public int RequestsCount { get; set; }
        public CourseLevel Level { get; set; }
        public int DurationWeeks { get; set; }
    }
}