using System;
using System.ComponentModel.DataAnnotations;

namespace School.Core.ShortModels
{
    public class PersonModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле -Имя- не может быть пустым")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Длина поля -Имя- должна быть 3-20")]
        [RegularExpression("^[а-яА-Я][а-яА-Я]*$", ErrorMessage = "Поле -Имя- должно содержать только буквы")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле -Фамилия- не может быть пустым")]
        [RegularExpression("^[а-яА-Я][а-яА-Я]*$", ErrorMessage = "Поле -Фамилия- должно содержать только буквы")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Длина поля -Фамилия- должна быть 3-20")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле -Возраст- не может быть пустым")]
        [Range(16, 90, ErrorMessage = "Возраст должен быть от 16 до 90 лет!")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Поле -Email- не может быть пустым")]
        [EmailAddress(ErrorMessage = "Некорректный -Email- адрес")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Длина поля -Email- должна быть 5-30, а также содержать символ @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле -Телефон- не может быть пустым")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Некорректный -Телефон-")]
        public string Phone { get; set; }
        public byte[] Photo { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
