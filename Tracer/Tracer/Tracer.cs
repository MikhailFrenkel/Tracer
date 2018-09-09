using System.Diagnostics;
using System.Reflection;

namespace Tracer
{
    public class CustomTracer : ITracer
    {
        private readonly TraceResult _traceResult;

        public CustomTracer()
        {
            _traceResult = new TraceResult();
        }

        public void StartTrace()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();
            _traceResult.StartMethodTrace(method);
        }

        public void StopTrace()
        {
            _traceResult.StopMethodTrace();
        }

        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }
    }
}
