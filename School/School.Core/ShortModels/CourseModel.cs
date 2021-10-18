using School.Core.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Core.ShortModels
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле -Title- не может быть пустым")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Длина для -Title- должна быть 2-50")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле -Description- не может быть пустым")]
        [StringLength(maximumLength: 1000, MinimumLength = 2, ErrorMessage = "Длина для <Description> должна быть 2-1000")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле -Program- не может быть пустым")]
        [StringLength(maximumLength: 500, MinimumLength = 2, ErrorMessage = "Длина для -Program- должна быть 2-500")]
        public string Program { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int RequestsCount { get; set; }
        public IEnumerable<StudentRequestModel> Requests { get; set; }
        public double? Price { get; set; }
        public CourseLevel Level { get; set; }
        public int DurationWeeks { get; set; }
    }
}