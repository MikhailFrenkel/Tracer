using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Tracer
{
    public delegate void TraceDelegate(object sender, TracerEventArgs e);

    public struct TraceResult
    {
        public string MethodName;
        public string ClassName;
        public long TimeExecution;
    }

    public class CustomTracer : ITracer
    {
        public event TraceDelegate OnStopTracing; 
        private TraceResult _traceResult;
        private Stopwatch _stopwatch;

        public void StartTrace()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();
            _traceResult.MethodName = method.Name;
            _traceResult.ClassName = method.DeclaringType?.Name;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void StopTrace()
        {
            _stopwatch.Stop();
            _traceResult.TimeExecution = _stopwatch.ElapsedMilliseconds;
            OnStopTracing?.Invoke(this, new TracerEventArgs(_traceResult));
        }

        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }
    }
}
