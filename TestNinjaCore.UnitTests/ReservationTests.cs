using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinjaCore.Fundamentals;

namespace TestNinjaCore.UnitTests
{
    [TestClass]
    public class ReservationTests 
    {
        // usual naming convention for unit tests
        // public void MethodName_Scenario_ExpectedBehavior()
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange - setup test
            var reservation = new Reservation();

            // Act - call method being tested
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }
    }
}
