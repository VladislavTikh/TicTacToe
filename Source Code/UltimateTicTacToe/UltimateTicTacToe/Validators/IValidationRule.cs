using System.Collections.Generic;

namespace UltimateTicTacToe.Validators
{
    public interface IValidationRule
    {
        bool Validate (string property, out ICollection<string> validationErrors);
    }
}