using System;
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

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();

            //logger.Log(error); // this will throw an exception and make test fail, need to use delegate instead
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);

            // if you need to assert for a certain type of exception can use this syntax
            // Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>());
            
        }
    }
}