using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class AircraftRoute
    {
        public AircraftRoute()
        {
            Flight = new HashSet<Flight>();
        }

        public int AircraftRouteId { get; set; }
        public string IcaoTypeCode { get; set; }
        public int RouteId { get; set; }

        public virtual Aircraft IcaoTypeCodeNavigation { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Flight> Flight { get; set; }
    }
}
