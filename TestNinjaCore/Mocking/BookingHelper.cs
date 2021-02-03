using System;
using System.Collections.Generic;
using System.Linq;

namespace TestNinjaCore.Mocking
{
    public static class BookingHelper
    {
        // ah.. this is static, should we switch to non static
        // because of the depenency.. right now need to pass in method...
        // private readonly IBookingRepository _repository;

        // public BookingHelper(IBookingRepository repository)
        // {
        //     this._repository = repository;
        // }

        // what tests?
        // if booking is null? - should return empty string - this is currently a bug
        // when booking is cancelled, should return empty string
        // when no overlapping bookings return empty string
        // when overlapping bookings return booking reference
        public static string OverlappingBookingsExist(Booking booking, IBookingRepository repository)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var overlappingBooking = repository.GetOverlappingBooking(booking);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }

    public class UnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }

    public class Booking
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Reference { get; set; }
    }
}