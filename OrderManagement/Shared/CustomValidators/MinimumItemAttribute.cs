using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.DTO.CustomValidators
{
    public class MinimumItemAttribute : ValidationAttribute
    {
        private readonly int _minElements;
        public MinimumItemAttribute(int minElements)
        {
            _minElements = minElements;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as IList;

            var result = list?.Count >= _minElements;

            return result
                ? ValidationResult.Success
                : new ValidationResult($"{validationContext.DisplayName} requires at least {_minElements} element(s)");
        }
    }
}
