using System;
using System.Collections.Generic;
using System.Linq;
using RightFlightEntityModel;

namespace RightFlightBusinessLayer
{
    public class CrudManager
    {
        public List<Airline> AirlineSearch(string search)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var airlineQuery =
                    from a in db.Airline
                    where a.Name.Contains(search)
                    select a;

                return airlineQuery.ToList();
            }
        }

        public List<Airport> AirportSearch(string search)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var airportQuery =
                    from a in db.Airport
                    where a.Name.Contains(search) || a.IataAirportCode.Contains(search)
                    select a;

                return airportQuery.ToList();
            }
        }

        public List<Aircraft> AircraftSearch(string search)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var aircraftQuery =
                    from a in db.Aircraft
                    where a.Model.Contains(search) || a.IcaoTypeCode.Contains(search)
                    select a;

                return aircraftQuery.ToList();
            }
        }
    }
}
