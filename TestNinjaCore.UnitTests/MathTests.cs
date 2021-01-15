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
    }
}