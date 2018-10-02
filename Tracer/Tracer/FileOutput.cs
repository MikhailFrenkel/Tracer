using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tracer
{
    public class FileOutput : IOutput
    {
        private readonly string _filePath;

        public FileOutput(string filePath)
        {
            _filePath = filePath;
        }

        public void Output(string value)
        {
            File.WriteAllText(_filePath, value);
        }
    }
}
