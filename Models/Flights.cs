using System;
namespace FlightsAPI.Models
{
	public class Flight
	{
		public int FlightId { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime FlightDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}

