using System;
namespace FlightsAPI.Models
{
	public class Passenger
	{
        public int PassengerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNum { get; set; }
        public string? EmailAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

