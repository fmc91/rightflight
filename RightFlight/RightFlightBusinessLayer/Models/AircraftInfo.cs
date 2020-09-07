using System;
using System.Collections.Generic;

namespace RightFlightBusinessLayer
{
    public class AircraftInfo
    {
        public string IcaoTypeCode { get; set; }

        public string Model { get; set; }

        public override string ToString()
        {
            return Model;
        }
    }
}
