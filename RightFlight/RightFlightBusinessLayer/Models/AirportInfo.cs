using System;
using System.Collections.Generic;

namespace RightFlightBusinessLayer
{
    public class AirportInfo
    {
        public string IataAirportCode { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
