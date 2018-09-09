using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Tracer
{
    internal class MethodResult
    {
        internal string Name { get; }
        internal string Class { get; }
        internal long Time { get; }
        internal List<MethodResult> Methods { get; }

        internal MethodResult(MethodBase methodBase)
        {
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

        }

        internal void StopMethodTrace()
        {

        }
    }
}
