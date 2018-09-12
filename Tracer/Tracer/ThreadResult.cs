using System;
using System.Collections.Generic;
using System.Reflection;

namespace Tracer
{
    public class ThreadResult
    {
        //TODO: thread time?
        public long Time { get; set; }

        public List<MethodResult> Methods { get; }
        private readonly Stack<MethodResult> _stack;

        internal ThreadResult()
        {
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
