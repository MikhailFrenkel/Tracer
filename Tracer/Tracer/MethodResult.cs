using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer
{
    public class MethodResult
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public long Time { get; set; }
        public List<MethodResult> Methods { get; set; }
    }
}
