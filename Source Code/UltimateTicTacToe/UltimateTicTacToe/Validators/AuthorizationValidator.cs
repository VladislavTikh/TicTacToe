using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.Validators
{
    public class AuthorizationValidator : IValidator
    {
        private IValidationRule _validationRule;

        public bool Validate(string property, string propertyName, out ICollection<string> validationErrors)
        {
            switch (propertyName)
            {
                case "Login":
                    _validationRule = new LoginValidationRule();
                    break;
                case "Password":
                    _validationRule = new PasswordValidationRule();
                    break;
                default:
                    break;
            }
            return _validationRule.Validate(property, out validationErrors);
        }
    }
}
