using Moq;
using NUnit.Framework;
using TestNinjaCore.Mocking;

namespace TestNinjaCore.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IBookingRepository>();
        }

        [Test]
        public void OverlappingBookingsExist_BookingIsCancelled_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking() { Status = "Cancelled" }, _repository.Object);

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void OverlappingBookingsExist_NoOverlappingBookings_ReturnEmptyString()
        {
            _repository
                .Setup(r => r.GetOverlappingBooking(It.IsAny<Booking>()))
                .Returns<Booking>(null);
            
            var result = BookingHelper.OverlappingBookingsExist(new Booking(), _repository.Object);

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void OverlappingBookingsExist_OverlappingBookingsExists_ReturnBookingReference()
        {
            _repository
                .Setup(r => r.GetOverlappingBooking(It.IsAny<Booking>()))
                .Returns(new Booking { Reference = "a" });
            
            var result = BookingHelper.OverlappingBookingsExist(new Booking(), _repository.Object);

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        [Ignore("Not ready yet")]
        public void OverlappingBookingsExist_BookingIsNull_ReturnEmptyString()
        {}
    }
}