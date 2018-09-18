using System.Linq;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tracer.Tests
{
    [TestClass]
    public class TracerTest
    {
        private TraceResult _traceResult;

        [TestInitialize]
        public void Init()
        {
            ITracer tracer = new CustomTracer();
            SomeMethod(tracer);
            _traceResult = tracer.TraceResult;
        }

        [TestMethod]
        public void TraceResult_TimeMoreOrEqual100()
        {
            long expected = 100;
            _traceResult.ThreadResults.Values.FirstOrDefault()?.Time
                .Should().BeGreaterOrEqualTo(expected, $"time should be more or equal 100ms");
        }

        [TestMethod]
        public void TraceResult_ThreadTime_MoreOrEqual200()
        {
            long expected = 200;
            _traceResult.ThreadResults.Values.FirstOrDefault()?.Time.Should()
                .BeGreaterOrEqualTo(expected, "thread time should be more or equal 200ms");
        }

        [TestMethod]
        public void TraceResult_MethodName_SomeMethod()
        {
            string expected = nameof(SomeMethod);
            _traceResult.ThreadResults.Values.FirstOrDefault()?.Methods[0].Name
                .Should().Be(expected, $"method name should be {expected}");
        }

        [TestMethod]
        public void TraceResult_ClassName_TracerTest()
        {
            string expected = "TracerTest";
            _traceResult.ThreadResults.Values.FirstOrDefault()?.Methods[0].Class
                .Should().Be(expected, $"class name should be {expected}");
        }

        [TestMethod]
        public void TraceResult_ThreadId()
        {
            int expectedId = Thread.CurrentThread.ManagedThreadId;
            _traceResult.ThreadResults.Keys
                .Should().Contain(expectedId, $"thread result should contain {expectedId} id");
        }



        private void SomeMethod(ITracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            OtherMethod(tracer);
            tracer.StopTrace();
        }

        private void OtherMethod(ITracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}
