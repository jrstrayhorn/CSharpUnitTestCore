using NUnit.Framework;
using TestNinjaCore.Fundamentals;

namespace TestNinjaCore.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            // no result - void method
            logger.Log("a");

            // testing the state of the object
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }
    }
}