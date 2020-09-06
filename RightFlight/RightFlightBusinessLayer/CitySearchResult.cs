using System;
using System.Collections.Generic;

namespace RightFlightBusinessLayer
{
    public class CitySearchResult
    {
        public string IataCityCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return City + ", " + Country;
        }
    }
}
