using System;

namespace School.Web.API.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}