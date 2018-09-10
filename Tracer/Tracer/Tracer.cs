using System.Diagnostics;
using System.Reflection;

namespace Tracer
{
    public class CustomTracer : ITracer
    {
        public TraceResult TraceResult { get; }

        public CustomTracer()
        {
            TraceResult = new TraceResult();
        }

        public void StartTrace()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();
            TraceResult.StartMethodTrace(method);
        }

        public void StopTrace()
        {
            TraceResult.StopMethodTrace();
        }
    }
}
