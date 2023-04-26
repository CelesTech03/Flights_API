using System;
namespace FlightsAPI.Models
{
    public class Booking
	{
        public int BookingId { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public string? SeatNum { get; set; }
    }
}

