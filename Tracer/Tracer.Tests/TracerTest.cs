using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tracer.Tests
{
    [TestClass]
    public class TracerTest
    {
        [TestMethod]
        public void TraceResult_NotNull()
        {
            ITracer tracer = new CustomTracer();
            SomeMethod(tracer);
            Assert.IsNotNull(tracer.TraceResult);
        }

        [TestMethod]
        public void TraceResult_TimeMoreOrEqual100()
        {
            ITracer tracer = new CustomTracer();
            SomeMethod(tracer);
            long time = tracer.TraceResult.ThreadResults[0].Time;
            if (time < 100)
                Assert.Fail();
        }

        [TestMethod]
        public void TraceResult_MethodName_SomeMethod()
        {
            string expected = "SomeMethod";
            ITracer tracer = new CustomTracer();
            SomeMethod(tracer);
            string actual = tracer.TraceResult.ThreadResults[0].Methods[0].Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TraceResult_ClassName_TracerTest()
        {
            string expected = "TracerTest";
            ITracer tracer = new CustomTracer();
            SomeMethod(tracer);
            string actual = tracer.TraceResult.ThreadResults[0].Methods[0].Class;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TraceResult_ThreadId()
        {
            int expectedId = Thread.CurrentThread.ManagedThreadId;
            ITracer tracer = new CustomTracer();
            SomeMethod(tracer);
            int actualId = tracer.TraceResult.ThreadResults[0].Id;
            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void TraceResult_ThreadTime_MoreOrEqual200()
        {
            long expected = 200;
            ITracer tracer = new CustomTracer();
            SomeMethod(tracer);
            if (expected > tracer.TraceResult.ThreadResults[0].Time)
                Assert.Fail();
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
