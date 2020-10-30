using System.Globalization;
using System.Windows.Controls;

namespace Alert_To_Care_Frontend.ValidationRules
{
    class IdValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string id = value as string;
            return string.IsNullOrEmpty(id) ? new ValidationResult(false, " * Required") : new ValidationResult(true, "");
        }
    }
}
