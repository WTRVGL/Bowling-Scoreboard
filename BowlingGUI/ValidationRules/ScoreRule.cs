using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Bowling.GUI.ValidationRules
{
    public class ScoreRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out var firstScoreResult))
                if (firstScoreResult > 10)
                    return new ValidationResult(false, "Score is meer dan 10");
            return ValidationResult.ValidResult;
        }
    }
}