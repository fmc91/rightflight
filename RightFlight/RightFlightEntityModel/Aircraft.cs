using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class Aircraft
    {
        public Aircraft()
        {
            AircraftRoute = new HashSet<AircraftRoute>();
        }

        public string IcaoTypeCode { get; set; }
        public string Model { get; set; }

        public virtual ICollection<AircraftRoute> AircraftRoute { get; set; }
    }
}
