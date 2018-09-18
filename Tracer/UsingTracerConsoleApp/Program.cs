using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Tracer;

namespace UsingTracerConsoleApp
{
    class Program
    {
        private static CustomTracer _tracer;
        private static List<Thread> _threads;

        static void Main()
        {
            _threads = new List<Thread>();
            _tracer = new CustomTracer();
            MultipleThreadMethod();
            XmlSerializer xmlSerializer = new XmlSerializer();
            xmlSerializer.Serialize(_tracer.TraceResult);
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(_tracer.TraceResult);
            Console.WriteLine(xmlSerializer.XmlResult);
            Console.WriteLine(jsonSerializer.JsonResult);
            File.WriteAllText("jsonResult.txt", jsonSerializer.JsonResult);
            File.WriteAllText("xmlResult.txt", xmlSerializer.XmlResult);
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
            if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
                SomeAction2();
            else
                SomeAction1();
            _tracer.StopTrace();
        }

        private static void Calculation()
        {
            _tracer.StartTrace();
            int res = 0;
            for (int i = 0; i < 1000; i++)
                res += i;
            if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
                SomeAction1();
            else
                SomeAction2();
            _tracer.StopTrace();
        }

        private static void SomeAction1()
        {
            _tracer.StartTrace();
            string s = "";
            for (int i = 0; i < 30; i++)
                s += i.ToString();
            _tracer.StopTrace();
        }

        private static void SomeAction2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
    }
}
