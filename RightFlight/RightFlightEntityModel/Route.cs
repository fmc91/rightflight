using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class Route
    {
        public Route()
        {
            RouteAircraft = new HashSet<RouteAircraft>();
        }

        public int RouteId { get; set; }
        public string AirlineCode { get; set; }
        public string OriginAirportCode { get; set; }
        public string DestinationAirportCode { get; set; }
        public string PricingScheme { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual Airport DestinationAirport { get; set; }
        public virtual Airport OriginAirport { get; set; }
        public virtual ICollection<RouteAircraft> RouteAircraft { get; set; }
    }
}
