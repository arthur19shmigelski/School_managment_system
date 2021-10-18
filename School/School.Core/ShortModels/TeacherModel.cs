using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace School.Core.ShortModels
{
    public class TeacherModel : PersonModel
    {
        [Required(ErrorMessage = "Поле -Ссылка на профиль- не может быть пустым")]
        public string LinkToProfile { get; set; }
    }
}