using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tracer
{
    public class ConsoleOutput : IOutput
    {
        public void Output(string value)
        {
            Console.WriteLine(value);
            
        }
    }
}
