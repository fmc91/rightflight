using System;
using System.Collections.Generic;

namespace RightFlightBusinessLayer
{
    public class RouteAircraftInfo
    {
        public int RouteAircraftId { get; set; }

        public string IcaoTypeCode { get; set; }

        public string Model { get; set; }

        public int FlightDuration { get; set; }
    }
}
