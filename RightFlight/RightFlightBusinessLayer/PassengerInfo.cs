using System;
using System.Collections.Generic;

namespace RightFlightBusinessLayer
{
    public class PassengerInfo
    {
        public int Index { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int NationalityId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Postcode { get; set; }
    }
}
