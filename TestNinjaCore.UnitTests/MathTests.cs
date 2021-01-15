using NUnit.Framework;
using TestNinjaCore.Fundamentals;

namespace TestNinjaCore.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        // don't do this
        // don't share state across state because it can leak
        // no singletons, should create a new instance each time
        // a test is being ran
        private Math _math;

        // SetUp - method will call method before running each test
        // can init object here
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        // TearDown - method will call after each test
        // often used with integration test
        // might create data in db and want to clean up after each test

        // using WhenCalled because scenario is generic or happens everytime
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            // each test should run/work like its the only test in the world
            // so no sharing or getting state from other tests
            // each test should start with a fresh and clean state
            // but we shouldn't repeat ourselves - DRY
            // var math = new Math();

            // use simple numbers as these numbers don't have a meaning
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        // good practice to write the method stubs w/ scenario and expected behavior
        // that way you don't miss any scenarios/expected behavior while writing tests
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var result = _math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var result = _math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }

        // good start is stubbing out methods based on execution paths
        // but should also take into account the types of data that can go into
        // method, also the results that might come out of method
        // in order words black box testing
        // not enough to just look at execution paths
        // will not account for missed behavior in implementation
        // imagine the method is just a black box (don't just rely on written implementation)
        // for example, Max method take two arguments what are types of arguments
        // a > b, a < b, also a = b - might miss this one if only looking at implementation
        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}