using System.Collections.Generic;
using System.Linq;

namespace UltimateTicTacToe.Validators
{
    public class PasswordValidationRule : IValidationRule
    {
        public int MaximumLength { get; set; }
        public int MinimumLength { get; set; }
        public char[] ForbiddenSymbols { get; set; }
        public PasswordValidationRule()
        {
            MaximumLength = 20;
            MinimumLength = 6;
            ForbiddenSymbols = new char[]
            {'!','@','#','$','%','^','&','+','=','*'};
        }
        public bool Validate(string password, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();
            if (string.IsNullOrEmpty(password))
            {
                validationErrors.Add($"Password cannot be empty");
            }
            if (password.Length < MinimumLength
                || password.Length > MaximumLength)
            {
                validationErrors.Add($"Password should be between {MinimumLength}" +
                    $" and {MaximumLength} symbols");
            }
            foreach (var symbol in ForbiddenSymbols)
            {
                if (password.Contains(symbol))
                {
                    validationErrors.Add("Password shouldn't contain forbidden symbols");
                    break;
                }
            }
            return validationErrors.Count == 0;
        }
    }
}