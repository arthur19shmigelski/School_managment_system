﻿using System;

namespace School.Core.ShortModels
{
    public class StudentRequestModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string Comments { get; set; }
        public DateTime ReadyToStartDate { get; set; }
        public int? GroupId { get; set; }
    }
}