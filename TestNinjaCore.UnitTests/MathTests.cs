using NUnit.Framework;
using TestNinjaCore.Fundamentals;

namespace TestNinjaCore.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        // using WhenCalled because scenario is generic or happens everytime
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var math = new Math();

            // use simple numbers as these numbers don't have a meaning
            var result = math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        // good practice to write the method stubs w/ scenario and expected behavior
        // that way you don't miss any scenarios/expected behavior while writing tests
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var math = new Math();

            var result = math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var math = new Math();

            var result = math.Max(1, 2);

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
            var math = new Math();

            var result = math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}