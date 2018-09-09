using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Tracer
{
    public class ThreadResult
    {
        public int Id { get; set; }
        public long Time { get; set; }
        public List<MethodResult> Methods { get; set; }

        public ThreadResult(int threadId)
        {
            Id = threadId;
        }

        internal void StartMethodTrace(MethodBase methodBase)
        {

        }

        internal void StopMethodTrace()
        {

        }
    }
}
