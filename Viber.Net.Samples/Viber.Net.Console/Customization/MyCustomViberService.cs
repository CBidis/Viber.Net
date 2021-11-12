using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viber.Net.Contracts;

namespace Viber.Net.Console.Customization
{
    /// <summary>
    /// My Custom Viber Service
    /// </summary>
    public class MyCustomViberService : ViberService, IViberService
    {
        public MyCustomViberService(IViberHttpClient viberHttpClient) : base(viberHttpClient)
        {
        }
    }
}
