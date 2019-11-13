using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace UltimateTicTacToe.Validators
{
    public class LoginValidationRule:IValidationRule
    {
        public int MaximumLength { get; set; }
        public int MinimumLength { get; set; }
        public char[] ForbiddenSymbols { get; set; }
        public LoginValidationRule()
        {
            MaximumLength = 20;
            MinimumLength = 3;
            ForbiddenSymbols = new char[]
            {'!','@','#','$','%','^','&','+','=','*'};
        }
        public bool Validate(string login, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();
            if (login.Length < MinimumLength
                || login.Length > MaximumLength)
            {
                validationErrors.Add($"Login should be between {MinimumLength}" +
                    $" and {MaximumLength} symbols");
            }
            foreach(var symbol in ForbiddenSymbols)
            {
                if(login.Contains(symbol))
                {
                    validationErrors.Add("Login shouldn't contain forbidden symbols");
                    break;
                }
            }
            return validationErrors.Count==0;
        }
    }
}
