using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class Flight
    {
        public Flight()
        {
            Booking = new HashSet<Booking>();
        }

        public int FlightId { get; set; }
        public int AircraftRouteId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime ScheduledDeparture { get; set; }
        public int EstimatedDuration { get; set; }

        public virtual AircraftRoute AircraftRoute { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
