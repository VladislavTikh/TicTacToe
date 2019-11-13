using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.Validators
{
    public interface IValidator
    {
        bool Validate(string property, string propertyName, out ICollection<string> validationErrors);
    }
}
