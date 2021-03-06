using System.Linq;
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

            // should always pass
            // when you write test later, might make a mistake
            // this is nto testing the right thing
            // this is not a trust worthy test because even though it pass
            // we still have a bug - it's not testing the right thing
            // how to prevent this???
            // go to production code, make a change to code that's supposed to make it pass
            // essentially create a bug, if test still passes then its not trust worthy
            // this means the test has a bug
            // Assert.That(_math, Is.Not.Null); 

            // when run test and pass
            // go to production code, and make a change (create a bug)
            // if test still pass then it's not testing the right thing!
        }

        // // good practice to write the method stubs w/ scenario and expected behavior
        // // that way you don't miss any scenarios/expected behavior while writing tests
        // [Test]
        // public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        // {
        //     var result = _math.Max(2, 1);

        //     Assert.That(result, Is.EqualTo(2));
        // }

        // we should delete or comment out tests
        // because there was a reason for the test
        // instead use the Ignore attribute
        [Test]
        [Ignore("Because I wanted to!")]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var result = _math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }

        // // good start is stubbing out methods based on execution paths
        // // but should also take into account the types of data that can go into
        // // method, also the results that might come out of method
        // // in order words black box testing
        // // not enough to just look at execution paths
        // // will not account for missed behavior in implementation
        // // imagine the method is just a black box (don't just rely on written implementation)
        // // for example, Max method take two arguments what are types of arguments
        // // a > b, a < b, also a = b - might miss this one if only looking at implementation
        // [Test]
        // public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        // {
        //     var result = _math.Max(1, 1);

        //     Assert.That(result, Is.EqualTo(1));
        // }

        // can use parameterized tests
        // can supply different arguments
        // with this method you don't need the other Max test methods
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        // use black box technique
        // input is an int
        // an int can be 0, <0 (negative), or >0 (positive)
        // that's three scenarios right there
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            // most general
            // can have any numbers
            // if you don't care about the values, this is ok
            Assert.That(result, Is.Not.Empty);

            // more specific
            // test number of items in array
            Assert.That(result.Count(), Is.EqualTo(3));

            // even more specific
            // check for existing of certain items
            // but don't care about order
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            // shorter and cleaner
            // this makes sure all items are in the result array
            // this is preferred way
            Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5}));

            // useful assertations
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique); // make sure no duplicate items in array
        }
    }
}