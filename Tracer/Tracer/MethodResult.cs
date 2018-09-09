using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Tracer
{
    internal class MethodResult
    {
        private readonly Stopwatch _stopwatch;
        internal string Name { get; }
        internal string Class { get; }
        internal long Time => _stopwatch.ElapsedMilliseconds;
        internal List<MethodResult> Methods { get; }

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
    }
}
