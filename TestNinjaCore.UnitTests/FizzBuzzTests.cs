using NUnit.Framework;
using TestNinjaCore.Fundamentals;

namespace TestNinjaCore.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        // method scenarios
        // if multiple of 3 and 5 print FizzBuzz
        // if multiple of 3 print Fuzz
        // if multiple of 5 print Buzz
        // if not return the original number as a string
        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(-3, "Fizz")]
        public void GetOutput_WhenNumberIsMultipleOfJustThree_ReturnFizz(int a, string expectedResult)
        {
            var result = FizzBuzz.GetOutput(a);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOutput_WhenNumberIsMultipleOfJustFive_ReturnBuzz()
        {}

        [Test]
        public void GetOutput_WhenNumberIsMultipleOfThreeAndFive_ReturnFizzBuzz()
        {}

        [Test]
        public void GetOutput_WhenNumberIsNotMultipleOfThreeOrFive_ReturnNumber()
        {}
    }
}