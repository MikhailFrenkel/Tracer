using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer
{
    public class TraceResult
    {
        private List<ThreadResult> _threadResults;

        internal TraceResult()
        {
            _threadResults = new List<ThreadResult>();
        }
    }
}
