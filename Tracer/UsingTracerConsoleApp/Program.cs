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
        private static CustomTracer _tracer;
        private static List<Thread> _threads;

        static void Main(string[] args)
        {
            _threads = new List<Thread>();
            _tracer = new CustomTracer();
            MultipleThreadMethod();
            //TraceResult traceResult = _tracer.GetTraceResult();
            //Console.WriteLine($"Class: {traceResult.ClassName}\n" +
            //                  $"Method: {traceResult.MethodName}\n" +
            //                  $"Time: {traceResult.TimeExecution}ms");
            Console.ReadLine();
        }

        private static void MultipleThreadMethod()
        {
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(SomeMethod) {IsBackground = true};
                _threads.Add(thread);
                thread.Start();
            }

            foreach (Thread t in _threads)
            {
                t.Join();
            }
        }

        private static void SomeMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(1000);
            Calculation();
            _tracer.StopTrace();
        }

        private static void Calculation()
        {
            _tracer.StartTrace();
            Thread.Sleep(500);
            _tracer.StopTrace();
        }
    }
}
