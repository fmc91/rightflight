using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class Route
    {
        public Route()
        {
            AircraftRoute = new HashSet<AircraftRoute>();
        }

        public int RouteId { get; set; }
        public string AirlineCode { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string PricingScheme { get; set; }

        public virtual Airline AirlineCodeNavigation { get; set; }
        public virtual Airport DestinationAirportNavigation { get; set; }
        public virtual Airport OriginAirportNavigation { get; set; }
        public virtual ICollection<AircraftRoute> AircraftRoute { get; set; }
    }
}
