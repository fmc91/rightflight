using System;
using System.Collections.Generic;

namespace RightFlightBusinessLayer
{
    public class AirlineInfo
    {
        public string IataAirlineCode { get; set; }

        public string Name { get; set; }

        public string LogoPath { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
