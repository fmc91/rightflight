﻿using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class City
    {
        public City()
        {
            Airport = new HashSet<Airport>();
        }

        public string IataCityCode { get; set; }
        public string Name { get; set; }
        public string TimeZone { get; set; }
        public string CountryCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual ICollection<Airport> Airport { get; set; }
    }
}
