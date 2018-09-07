using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer
{
    public class TracerEventArgs
    {
        public TraceResult TraceResult { get; private set; }

        public TracerEventArgs(TraceResult traceResult)
        {
            TraceResult = traceResult;
        }
    }
}
