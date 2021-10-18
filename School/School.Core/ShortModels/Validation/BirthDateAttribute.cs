using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace School.Core.ShortModels.Validation
{
    public class BirthDateAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _minAge;
        private readonly int _maxAge;

        public BirthDateAttribute(int minAge, int maxAge = 100)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-birthdate", "Must be older than 18");
        }

        public override bool IsValid(object value)
        {
            var age = (DateTime.Today - (DateTime)value).TotalDays * 365;

            return age > _minAge && age < _maxAge;
        }
    }
}
