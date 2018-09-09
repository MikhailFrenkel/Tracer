using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;

namespace Tracer
{
    public class CustomTracer : ITracer
    {
        public TraceResult _traceResult { get; }

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
