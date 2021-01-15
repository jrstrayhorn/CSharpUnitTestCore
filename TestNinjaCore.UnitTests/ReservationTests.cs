using TestNinjaCore.Fundamentals;
using NUnit.Framework;

namespace TestNinjaCore.UnitTests
{
    [TestFixture]
    public class ReservationTests 
    {
        // usual naming convention for unit tests
        // public void MethodName_Scenario_ExpectedBehavior()
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            // Arrange - setup test
            var reservation = new Reservation();

            // Act - call method being tested
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            // Assert.IsTrue(result);
            Assert.That(result, Is.True);
            // Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation() { MadeBy = user };
            
            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            var reservation = new Reservation() { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }
}
