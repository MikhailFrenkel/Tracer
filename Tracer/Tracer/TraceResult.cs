using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Tracer
{
    public class TraceResult
    {
        public ConcurrentDictionary<int, ThreadResult> ThreadResults { get; }

        internal TraceResult()
        {
            ThreadResults = new ConcurrentDictionary<int, ThreadResult>();
        }

        internal void StartMethodTrace(MethodBase methodBase)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            if (ThreadResults.ContainsKey(threadId))
            {
                ThreadResults[threadId].StartMethodTrace(methodBase);
            }
            else
            {
                ThreadResult threadResult = new ThreadResult();
                ThreadResults.GetOrAdd(threadId, threadResult);
                threadResult.StartMethodTrace(methodBase);
            }
        }

        internal void StopMethodTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            ThreadResults[threadId]?.StopMethodTrace();
        }
    }
}
