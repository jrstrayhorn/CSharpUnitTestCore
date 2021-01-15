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

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            // how can we verify event was raised
            // before acting need to subscribe to event
            // the lamba is the event handler
            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        // [Test]
        // public void OnErrorLogged_WhenCalled_RaiseEvent()
        // {
        //     var logger = new ErrorLogger();

        //     // now the tests break
        //     // now tests break again when refactoring!!
        //     logger.OnErrorLogged(Guid.NewGuid());

        //     Assert.That(true);
        // }
    }
}