using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Tracer
{
    public class TraceResult
    {
        private readonly List<ThreadResult> _threadResults;

        internal TraceResult()
        {
            _threadResults = new List<ThreadResult>();
        }

        internal void StartMethodTrace(MethodBase methodBase)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            if (_threadResults.Exists(x => x.Id == threadId))
            {
                _threadResults.Find(x => x.Id == threadId).StartMethodTrace(methodBase);
            }
            else
            {
                ThreadResult threadResult = new ThreadResult(threadId);
                _threadResults.Add(threadResult);
                threadResult.StartMethodTrace(methodBase);
            }
        }

        internal void StopMethodTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            _threadResults.Find(x => x.Id == threadId)?.StopMethodTrace();
        }
    }
}
