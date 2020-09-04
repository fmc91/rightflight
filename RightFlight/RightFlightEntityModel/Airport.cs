using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class Airport
    {
        public Airport()
        {
            RouteDestinationAirportCodeNavigation = new HashSet<Route>();
            RouteOriginAirportCodeNavigation = new HashSet<Route>();
        }

        public string IataAirportCode { get; set; }
        public string Name { get; set; }
        public string CityCode { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Route> RouteDestinationAirportCodeNavigation { get; set; }
        public virtual ICollection<Route> RouteOriginAirportCodeNavigation { get; set; }
    }
}
