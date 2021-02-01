using System;
using NUnit.Framework;
using TestNinjaCore.Fundamentals;

namespace TestNinjaCore.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeedIsLessThanZero_ThrowException()
        { 
            Assert.That(() => _calculator.CalculateDemeritPoints(-10), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeedIsGreaterThanMaxSpeed_ThrowException()
        { 
            Assert.That(() => _calculator.CalculateDemeritPoints(301), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeedIsLessThanSpeedLimit_ReturnZero()
        { 
            var result = _calculator.CalculateDemeritPoints(20);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeedIsEqualToSpeedLimit_ReturnZero()
        { 
            var result = _calculator.CalculateDemeritPoints(65);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeedIsOverSpeedLimit_ReturnCorrectDemeritPoints()
        { 
            var result = _calculator.CalculateDemeritPoints(80);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}