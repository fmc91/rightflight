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

        public void AddRoute(string iataAirlineCode, string originAirportCode, string destinationAirportCode, List<FlightDuration> flightDurations, List<ClassPricingScheme> pricingSchemes)
        {
            if (DoesRouteExist(iataAirlineCode, originAirportCode, destinationAirportCode))
                throw new InvalidOperationException("Route already exists.");

            using (FlightReservationContext db = new FlightReservationContext())
            {
                Route route = new Route
                {
                    AirlineCode = iataAirlineCode,
                    OriginAirportCode = originAirportCode,
                    DestinationAirportCode = destinationAirportCode,
                    PricingScheme = JsonConvert.SerializeObject(pricingSchemes)
                };

                db.Route.Add(route);
                db.SaveChanges();

                foreach (FlightDuration fd in flightDurations)
                {
                    RouteAircraft aircraftRoute = new RouteAircraft
                    {
                        RouteId = route.RouteId,
                        IcaoTypeCode = fd.Aircraft.IcaoTypeCode,
                        FlightDuration = fd.DurationHours * 60 + fd.DurationMinutes
                    };

                    db.RouteAircraft.Add(aircraftRoute);
                }

                db.SaveChanges();
            }
        }

        public void AddFlight(int routeAircraftId, string flightNumber, DateTime scheduledDeparture)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                Flight flight = new Flight
                {
                    RouteAircraftId = routeAircraftId,
                    FlightNumber = flightNumber,
                    ScheduledDeparture = scheduledDeparture
                };

                db.Flight.Add(flight);
                db.SaveChanges();
            }
        }

        public List<RouteInfo> GetRoutes(string iataAirlineCode, string iataAirportCode)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var routeQuery =
                    from r in db.Route
                    join al in db.Airline on r.AirlineCode equals al.IataAirlineCode
                    join or in db.Airport on r.OriginAirportCode equals or.IataAirportCode
                    join ds in db.Airport on r.DestinationAirportCode equals ds.IataAirportCode
                    where r.AirlineCode == iataAirlineCode &&
                         (r.OriginAirportCode == iataAirportCode ||
                          r.DestinationAirportCode == iataAirportCode)
                    select new RouteInfo
                    {
                        RouteId = r.RouteId,
                        AirlineCode = iataAirlineCode,
                        Airline = al.Name,
                        OriginAirportCode = or.IataAirportCode,
                        OriginAirport = or.Name,
                        DestinationAirportCode = ds.IataAirportCode,
                        DestinationAirport = ds.Name
                    };

                return routeQuery.ToList();
            }
        }

        public List<RouteInfo> GetRoutes(string iataAirlineCode)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var routeQuery =
                    from r in db.Route
                    join al in db.Airline on r.AirlineCode equals al.IataAirlineCode
                    join or in db.Airport on r.OriginAirportCode equals or.IataAirportCode
                    join ds in db.Airport on r.DestinationAirportCode equals ds.IataAirportCode
                    where r.AirlineCode == iataAirlineCode
                    select new RouteInfo
                    {
                        RouteId = r.RouteId,
                        AirlineCode = iataAirlineCode,
                        Airline = al.Name,
                        OriginAirportCode = or.IataAirportCode,
                        OriginAirport = or.Name,
                        DestinationAirportCode = ds.IataAirportCode,
                        DestinationAirport = ds.Name
                    };

                return routeQuery.ToList();
            }
        }

        public List<RouteAircraftInfo> GetRouteAircraftInfoByRouteId(int routeId)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var aircraftRouteQuery =
                    from ra in db.RouteAircraft
                    join a in db.Aircraft on ra.IcaoTypeCode equals a.IcaoTypeCode
                    where ra.RouteId == routeId
                    select new RouteAircraftInfo
                    {
                        RouteAircraftId = ra.RouteAircraftId,
                        IcaoTypeCode = a.IcaoTypeCode,
                        Model = a.Model,
                        FlightDuration = ra.FlightDuration
                    };

                return aircraftRouteQuery.ToList();
            }

        }

        private bool DoesRouteExist(string iataAirlineCode, string originAirportCode, string destinationAirportCode)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var routeQuery =
                    from r in db.Route
                    join al in db.Airline on r.AirlineCode equals al.IataAirlineCode
                    join or in db.Airport on r.OriginAirportCode equals or.IataAirportCode
                    join ds in db.Airport on r.DestinationAirportCode equals ds.IataAirportCode
                    where al.IataAirlineCode == iataAirlineCode &&
                          or.IataAirportCode == originAirportCode &&
                          ds.IataAirportCode == destinationAirportCode
                    select r;

                return routeQuery.Any();
            }
        }
    }
}
