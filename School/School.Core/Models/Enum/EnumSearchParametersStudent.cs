using System.ComponentModel.DataAnnotations;

namespace School.Core.Models.Enum
{
    public enum EnumSearchParametersStudent
    {
        [Display(Name = "Выберите поиск")]
        none = 0,
        [Display(Name = "По имени")]
        FirstName,
        [Display(Name = "По фамилии")]
        LastName,
    }
}