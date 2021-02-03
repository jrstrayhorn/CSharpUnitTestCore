using Moq;
using NUnit.Framework;
using TestNinjaCore.Mocking;
using System.Linq;
using System.Collections.Generic;
using System;

namespace TestNinjaCore.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExist_Tests
    {
        private Mock<IBookingRepository> _repository;
        private Booking _existingBooking;

        [SetUp]
        public void SetUp()
        {
            _existingBooking = new Booking
                    {
                        Id = 2,
                        ArrivalDate = ArriveOn(2017, 1, 15),
                        DepartureDate = DepartOn(2017, 1, 20),
                        Reference = "a"
                    };
            
            _repository = new Mock<IBookingRepository>();
            _repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
                {
                    _existingBooking
                }.AsQueryable());
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingBooking.ArrivalDate)
            }, _repository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.ArrivalDate)
            }, _repository.Object);

            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.DepartureDate)
            }, _repository.Object);

            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }

        [Test]
        public void OverlappingBookingsExist_BookingIsCancelled_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking() { Status = "Cancelled" }, _repository.Object);

            Assert.That(result, Is.EqualTo(""));
        }

        // [Test]
        // public void OverlappingBookingsExist_NoOverlappingBookings_ReturnEmptyString()
        // {
        //     _repository
        //         .Setup(r => r.GetOverlappingBooking(It.IsAny<Booking>()))
        //         .Returns<Booking>(null);
            
        //     var result = BookingHelper.OverlappingBookingsExist(new Booking(), _repository.Object);

        //     Assert.That(result, Is.EqualTo(""));
        // }

        // [Test]
        // public void OverlappingBookingsExist_OverlappingBookingsExists_ReturnBookingReference()
        // {
        //     _repository
        //         .Setup(r => r.GetOverlappingBooking(It.IsAny<Booking>()))
        //         .Returns(new Booking { Reference = "a" });
            
        //     var result = BookingHelper.OverlappingBookingsExist(new Booking(), _repository.Object);

        //     Assert.That(result, Is.EqualTo("a"));
        // }

        [Test]
        [Ignore("Not ready yet")]
        public void OverlappingBookingsExist_BookingIsNull_ReturnEmptyString()
        {}
    }
}