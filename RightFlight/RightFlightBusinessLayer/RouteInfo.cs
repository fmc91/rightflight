using System;
using System.Collections.Generic;

namespace RightFlightBusinessLayer
{
    public class RouteInfo
    {
        public int RouteId { get; set; }

        public string AirlineCode { get; set; }

        public string Airline { get; set; }

        public string OriginAirportCode { get; set; }

        public string OriginAirport { get; set; }

        public string DestinationAirportCode { get; set; }

        public string DestinationAirport { get; set; }
    }
}
