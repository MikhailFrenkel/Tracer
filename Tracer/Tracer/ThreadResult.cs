using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer
{
    public class ThreadResult
    {
        public int Id { get; set; }
        public long Time { get; set; }
        public List<MethodResult> Methods { get; set; }
    }
}
