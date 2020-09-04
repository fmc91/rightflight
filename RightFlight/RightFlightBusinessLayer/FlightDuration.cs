using RightFlightEntityModel;
using System;
using System.Collections.Generic;

namespace RightFlightBusinessLayer
{
    public class FlightDuration
    {
        public Aircraft Aircraft { get; set; }

        public int DurationHours { get; set; }

        public int DurationMinutes { get; set; }
    }
}
