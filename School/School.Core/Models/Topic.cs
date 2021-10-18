using System.Collections.Generic;

namespace School.Core.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public Topic Parent { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}