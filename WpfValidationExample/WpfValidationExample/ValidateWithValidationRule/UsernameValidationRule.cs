using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfValidationExample.ValidateWithValidationRule
{
    public class UsernameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string username = (string)value;

            if (username.Length < Length)
            {
                return new ValidationResult(false, "Username must be length >= 5");
            } else
            {
                return new ValidationResult(true, null);
            }
        }

        public int Length { get; set; } = 5;
    }
}
