using System;
using System.Collections.Generic;

namespace RightFlightEntityModel
{
    public partial class TravelClass
    {
        public TravelClass()
        {
            Booking = new HashSet<Booking>();
        }

        public string TravelClassCode { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
