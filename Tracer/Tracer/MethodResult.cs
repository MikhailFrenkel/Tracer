using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Tracer
{
    public class MethodResult
    {
        private readonly Stopwatch _stopwatch;
        public string Name { get; }
        public string Class { get; }
        public long Time => _stopwatch.ElapsedMilliseconds;
        public List<MethodResult> Methods { get; }

        internal MethodResult(MethodBase methodBase)
        {
            _stopwatch = new Stopwatch();
            Methods = new List<MethodResult>();
            Name = methodBase.Name;
            Class = methodBase.DeclaringType?.Name;
        }

        internal void AddMethod(MethodResult method)
        {
            Methods.Add(method);
        }

        internal void StartMethodTrace()
        {
            _stopwatch.Start();
        }

        internal void StopMethodTrace()
        {
            _stopwatch.Stop();
        }

        internal long SumTime(long res)
        {
            res += Time;
            foreach (var method in Methods)
            {
                res = method.SumTime(res);
            }
            return res;
        }
    }
}
