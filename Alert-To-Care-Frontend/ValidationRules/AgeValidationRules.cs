using System.Globalization;
using System.Windows.Controls;

namespace Alert_To_Care_Frontend.ValidationRules
{
    class AgeValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue))
            {
                return new ValidationResult(false, " * Required");
            }
            return CheckForPositiveAge(stringValue);
        }

        private ValidationResult CheckForPositiveAge(string value)
        {
            if (!int.TryParse(value, out int age))
            {
                return new ValidationResult(false, " Age must be a valid number!");
            }
            if (age <= 0)
            {
                return new ValidationResult(false, " Age must be greater than 0!");
            }
            return new ValidationResult(true, "");
        }
    }
}


