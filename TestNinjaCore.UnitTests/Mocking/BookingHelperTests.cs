using Moq;
using NUnit.Framework;
using TestNinjaCore.Mocking;
using System.Linq;
using System.Collections.Generic;

namespace TestNinjaCore.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExist_Tests
    {
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IBookingRepository>();
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            _repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
                {
                    new Booking
                    {
                        Id = 2,
                        ArrivalDate = new System.DateTime(2017, 1, 15, 14, 0, 0),
                        DepartureDate = new System.DateTime(2017, 1, 20, 10, 0, 0),
                        Reference = "a"
                    }
                }.AsQueryable());
            
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = new System.DateTime(2017, 1, 10, 14, 0, 0),
                DepartureDate = new System.DateTime(2017, 1, 14, 10, 0, 0),
            }, _repository.Object);

            Assert.That(result, Is.Empty);
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