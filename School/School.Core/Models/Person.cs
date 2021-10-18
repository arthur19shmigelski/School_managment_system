using System;
using System.ComponentModel.DataAnnotations;

namespace School.Core.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле <FirstName> не может быть пустым")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле <LastName> не может быть пустым")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле <Age> не может быть пустым")]
        [Range(16, 90, ErrorMessage = "Возраст должен быть от 16 до 90 лет!")]
        public int? Age { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
        public byte[] Photo { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
