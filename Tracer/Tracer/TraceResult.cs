using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Tracer
{
    public class TraceResult
    {
        public List<ThreadResult> ThreadResults { get; }

        internal TraceResult()
        {
            ThreadResults = new List<ThreadResult>();
        }

        internal void StartMethodTrace(MethodBase methodBase)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            if (ThreadResults.Exists(x => x.Id == threadId))
            {
                ThreadResults.Find(x => x.Id == threadId).StartMethodTrace(methodBase);
            }
            else
            {
                ThreadResult threadResult = new ThreadResult(threadId);
                ThreadResults.Add(threadResult);
                threadResult.StartMethodTrace(methodBase);
            }
        }

        internal void StopMethodTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            ThreadResults.Find(x => x.Id == threadId)?.StopMethodTrace();
        }
    }
}
