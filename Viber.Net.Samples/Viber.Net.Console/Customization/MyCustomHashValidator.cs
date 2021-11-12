using Viber.Net.Configuration;
using Viber.Net.Contracts;
using Viber.Net.Implementations;

namespace Viber.Net.Console.Customization
{
    /// <summary>
    /// My Custom hash Validator
    /// </summary>
    public class MyCustomHashValidator : HMACSha256Validator, IHashValidator
    {
        public MyCustomHashValidator(ViberSettings viberSettings) : base(viberSettings)
        {
        }
    }
}
