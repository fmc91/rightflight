using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class Airport
    {
        public Airport()
        {
            RouteDestinationAirportNavigation = new HashSet<Route>();
            RouteOriginAirportNavigation = new HashSet<Route>();
        }

        public string IataAirportCode { get; set; }
        public string Name { get; set; }
        public string CityCode { get; set; }

        public virtual City CityCodeNavigation { get; set; }
        public virtual ICollection<Route> RouteDestinationAirportNavigation { get; set; }
        public virtual ICollection<Route> RouteOriginAirportNavigation { get; set; }
    }
}
