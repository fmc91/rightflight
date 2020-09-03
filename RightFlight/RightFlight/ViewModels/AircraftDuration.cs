using RightFlightEntityModel;
using System;
using System.Collections.Generic;

namespace RightFlight
{
    public class AircraftDuration
    {
        public Aircraft Aircraft { get; set; }

        public int DurationHours { get; set; }

        public int DurationMinutes { get; set; }
    }
}
