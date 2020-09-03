using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class Airline
    {
        public Airline()
        {
            Route = new HashSet<Route>();
        }

        public string IataAirlineCode { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }

        public virtual ICollection<Route> Route { get; set; }
    }
}
