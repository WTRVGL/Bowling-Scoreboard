using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bowling.GUI.ValidationRules
{

    /// <summary>
    /// Validation rule for determining whether an input is numeric or not.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ValidationRule" />
    public class ScoreNumericValidationRule : ValidationRule
    {

        /// <summary>
        /// Implementation of the abstract class
        /// </summary>
        /// <param name="value">The value from the binding target to check.</param>
        /// <returns>
        /// A <see cref="T:System.Windows.Controls.ValidationResult" /> object.
        /// </returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //Tries to parse value and returns a ValidationResult with an error message if parse failed.
            var result = int.TryParse((string)value, out int score);
            if (!result)
            {
                return new ValidationResult(false, "Niet numerieke input");
            }

            return new ValidationResult(true, null);
        }
    }
}
