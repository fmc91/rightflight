using System;
using System.Collections.Generic;
using System.Linq;
using RightFlightEntityModel;
using Newtonsoft.Json;

namespace RightFlightBusinessLayer
{
    public class CrudManager
    {
        public List<TravelClass> GetTravelClasses()
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var query =
                    from tc in db.TravelClass
                    select tc;

                return query.ToList();
            }
        }

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
                    join c in db.City on a.CityCode equals c.IataCityCode
                    where a.Name.Contains(search) || c.Name.Contains(search) || a.IataAirportCode.Contains(search)
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

        public void AddRoute(Airline airline, Airport origin, Airport destination, List<FlightDuration> flightDurations, List<ClassPricingScheme> pricingSchemes)
        {
            if (DoesRouteExist(airline, origin, destination))
                throw new InvalidOperationException("Route already exists.");

            using (FlightReservationContext db = new FlightReservationContext())
            {
                Route route = new Route
                {
                    AirlineCode = airline.IataAirlineCode,
                    OriginAirport = origin.IataAirportCode,
                    DestinationAirport = destination.IataAirportCode,
                    PricingScheme = JsonConvert.SerializeObject(pricingSchemes)
                };

                db.Route.Add(route);
                db.SaveChanges();

                foreach (FlightDuration fd in flightDurations)
                {
                    AircraftRoute aircraftRoute = new AircraftRoute
                    {
                        RouteId = route.RouteId,
                        IcaoTypeCode = fd.Aircraft.IcaoTypeCode,
                        FlightDuration = fd.DurationHours * 60 + fd.DurationMinutes
                    };

                    db.AircraftRoute.Add(aircraftRoute);
                }

                db.SaveChanges();
            }
        }

        private bool DoesRouteExist(Airline airline, Airport origin, Airport destination)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var routeQuery =
                    from r in db.Route
                    join al in db.Airline on r.AirlineCode equals al.IataAirlineCode
                    join or in db.Airport on r.OriginAirport equals or.IataAirportCode
                    join ds in db.Airport on r.DestinationAirport equals ds.IataAirportCode
                    where al.IataAirlineCode == airline.IataAirlineCode &&
                          or.IataAirportCode == origin.IataAirportCode &&
                          ds.IataAirportCode == destination.IataAirportCode
                    select r;

                return routeQuery.Any();
            }
        }
    }
}
