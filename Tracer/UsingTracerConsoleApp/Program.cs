using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tracer;

namespace UsingTracerConsoleApp
{
    class Program
    {
        private static ITracer _tracer;

        static void Main(string[] args)
        {
            _tracer = new CustomTracer();
            SomeMethod();
            TraceResult traceResult = _tracer.GetTraceResult();
            Console.WriteLine($"Class: {traceResult.ClassName}\n" +
                              $"Method: {traceResult.MethodName}\n" +
                              $"Time: {traceResult.TimeExecution}ms");
            Console.ReadLine();
        }

        private static void SomeMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(1000);
            _tracer.StopTrace();
        }
    }
}
