using System;
using System.Collections.Generic;
using System.Text;

namespace RightFlightBusinessLayer
{
    public class FlightSearchResult
    {
        public int FlightId { get; set; }

        public string OriginAirportCode { get; set; }

        public string OriginAirport { get; set; }

        public string OriginCity { get; set; }

        public string OriginCountry { get; set; }

        public string DestinationAirportCode { get; set; }

        public string DestinationAirport { get; set; }

        public string DestinationCity { get; set; }

        public string DestinationCountry { get; set; }

        public string Airline { get; set; }

        public string AirlineLogoPath { get; set; }

        public string FlightNumber { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public TimeSpan FlightDuration { get; set; }

        public List<TicketPriceInfo> TicketPrices { get; set; }

        public string AircraftType { get; set; }
    }
}
