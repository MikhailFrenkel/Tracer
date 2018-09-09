using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tracer
{
    internal class ThreadResult
    {
        internal int Id { get; set; }
        internal long Time => Methods.Sum(x => x.Time);
        internal List<MethodResult> Methods { get; set; }
        private readonly Stack<MethodResult> _stack;

        internal ThreadResult(int threadId)
        {
            Id = threadId;
            Methods = new List<MethodResult>();
            _stack = new Stack<MethodResult>();
        }

        internal void StartMethodTrace(MethodBase methodBase)
        {
            MethodResult method = new MethodResult(methodBase);
            if (_stack.Count == 0)
            {
                Methods.Add(method);
            }
            else
            {
                _stack.Peek().AddMethod(method);
            }
            _stack.Push(method);
            method.StartMethodTrace();
        }

        internal void StopMethodTrace()
        {
            _stack.Pop().StopMethodTrace();
        }
    }
}
