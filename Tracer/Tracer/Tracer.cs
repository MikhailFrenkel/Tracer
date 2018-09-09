using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Tracer
{
    public class CustomTracer : ITracer
    {
        private TraceResult _traceResult;

        public CustomTracer()
        {
            _traceResult = new TraceResult();
        }

        public void StartTrace()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();
            int threadId = Thread.CurrentThread.ManagedThreadId;
            

            
            //_traceResult.MethodName = method.Name;
            //_traceResult.ClassName = method.DeclaringType?.Name;
            //_stopwatch = new Stopwatch();
            //_stopwatch.Start();
        }

        public void StopTrace()
        {
            //_stopwatch.Stop();
            //_traceResult.TimeExecution = _stopwatch.ElapsedMilliseconds;
        }

        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }
    }
}
