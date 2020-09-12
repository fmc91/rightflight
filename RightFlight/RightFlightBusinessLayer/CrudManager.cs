using System;
using System.Collections.Generic;
using System.Linq;
using RightFlightEntityModel;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace RightFlightBusinessLayer
{
    public class CrudManager
    {
        public async Task<List<TravelClassInfo>> GetTravelClasses()
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var query =
                    from tc in db.TravelClass
                    select new TravelClassInfo
                    {
                        TravelClassCode = tc.TravelClassCode,
                        Name = tc.Name
                    };

                return await query.ToListAsync();
            }   
    }

        public async Task<List<NationalityInfo>> GetNationalities()
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var nationalityQuery =
                    from n in db.Nationality
                    select new NationalityInfo
                    {
                        NationalityId = n.NationalityId,
                        CountryName = n.CountryName
                    };

                return await nationalityQuery.ToListAsync();
            }
        }

        public async Task<List<AirlineInfo>> AirlineSearch(string search)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var airlineQuery =
                    from a in db.Airline
                    where a.Name.Contains(search)
                    select new AirlineInfo
                    {
                        IataAirlineCode = a.IataAirlineCode,
                        Name = a.Name,
                        LogoPath = a.LogoPath
                    };

                return await airlineQuery.ToListAsync();
            }
        }

        public async Task<List<AirportInfo>> AirportSearch(string search)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var airportQuery =
                    from a in db.Airport
                    join c in db.City on a.CityCode equals c.IataCityCode
                    where a.Name.Contains(search) || c.Name.Contains(search) || a.IataAirportCode == search
                    select new AirportInfo
                    {
                        IataAirportCode = a.IataAirportCode,
                        Name = a.Name
                    };

                return await airportQuery.ToListAsync();
            }
        }

        public async Task<List<AircraftInfo>> AircraftSearch(string search)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var aircraftQuery =
                    from a in db.Aircraft
                    where a.Model.Contains(search) || a.IcaoTypeCode.Contains(search)
                    select new AircraftInfo
                    {
                        IcaoTypeCode = a.IcaoTypeCode,
                        Model = a.Model
                    };

                return await aircraftQuery.ToListAsync();
            }
        }

        public async Task<List<CityInfo>> CitySearch(string search)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var cityQuery =
                    from ci in db.City
                    join co in db.Country on ci.CountryCode equals co.IsoCountryCode
                    where ci.Name.Contains(search)
                    select new CityInfo
                    {
                        IataCityCode = ci.IataCityCode,
                        City = ci.Name,
                        Country = co.Name
                    };

                return await cityQuery.ToListAsync();
            }
        }

        public async Task<List<FlightInfo>> FlightSearch(string originCityCode, string destinationCityCode, int adults, int children, int infants)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var query =
                    from f in db.Flight
                    join ra in db.RouteAircraft on f.RouteAircraftId equals ra.RouteAircraftId
                    join ac in db.Aircraft on ra.IcaoTypeCode equals ac.IcaoTypeCode
                    join r in db.Route on ra.RouteId equals r.RouteId
                    join al in db.Airline on r.AirlineCode equals al.IataAirlineCode
                    join oap in db.Airport on r.OriginAirportCode equals oap.IataAirportCode
                    join oci in db.City on oap.CityCode equals oci.IataCityCode
                    join oco in db.Country on oci.CountryCode equals oco.IsoCountryCode
                    join dap in db.Airport on r.DestinationAirportCode equals dap.IataAirportCode
                    join dci in db.City on dap.CityCode equals dci.IataCityCode
                    join dco in db.Country on dci.CountryCode equals dco.IsoCountryCode
                    where oci.IataCityCode == originCityCode &&
                          dci.IataCityCode == destinationCityCode
                    orderby f.ScheduledDeparture
                    select new FlightInfo
                    {
                        FlightId = f.FlightId,
                        OriginAirportCode = oap.IataAirportCode,
                        OriginAirport = oap.Name,
                        OriginCity = oci.Name,
                        OriginCountry = oco.Name,
                        DestinationAirportCode = dap.IataAirportCode,
                        DestinationAirport = dap.Name,
                        DestinationCity = dci.Name,
                        DestinationCountry = dco.Name,
                        Airline = al.Name,
                        AirlineLogoPath = al.LogoPath,
                        DepartureTime = f.ScheduledDeparture,
                        ArrivalTime = ArrivalTime.Calculate(f.ScheduledDeparture, ra.FlightDuration, oci.TimeZone, dci.TimeZone),
                        FlightDuration = TimeSpan.FromMinutes(ra.FlightDuration),
                        FlightNumber = f.FlightNumber,
                        TicketPrices = TicketPrice.Calculate(JsonConvert.DeserializeObject<List<ClassPricingScheme>>(r.PricingScheme),
                                                             adults, children, infants),
                        AircraftType = ac.Model                        
                    };

                return await query.ToListAsync();
            }
        }

        public async Task AddRoute(string iataAirlineCode, string originAirportCode, string destinationAirportCode,
                             List<FlightDuration> flightDurations, List<ClassPricingScheme> pricingSchemes)
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
                await db.SaveChangesAsync();

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

                await db.SaveChangesAsync();
            }
        }

        public async Task AddFlight(int routeAircraftId, string flightNumber, DateTime scheduledDeparture)
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
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<RouteInfo>> GetRoutes(string iataAirlineCode, string iataAirportCode)
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

                return await routeQuery.ToListAsync();
            }
        }

        public async Task<List<RouteInfo>> GetRoutes(string iataAirlineCode)
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

                return await routeQuery.ToListAsync();
            }
        }

        public async Task<List<RouteAircraftInfo>> GetRouteAircraftInfoByRouteId(int routeId)
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

                return await aircraftRouteQuery.ToListAsync();
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

        public async Task<string> CreateBooking(int flightId, string travelClassCode, float amount, List<PassengerInfo> passengers)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                Booking booking = new Booking
                {
                    FlightId = flightId,
                    BookingReference = BookingReference.Generate(),
                    TravelClassCode = travelClassCode,
                    Cost = (decimal)amount,
                    TimeOfBooking = DateTime.Now
                };

                db.Booking.Add(booking);
                db.SaveChanges();

                foreach (PassengerInfo p in passengers)
                {
                    Passenger passenger = new Passenger
                    {
                        BookingId = booking.BookingId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        DateOfBirth = p.DateOfBirth,
                        NationalityId = p.NationalityId,
                        Address = p.Address,
                        City = p.City,
                        Country = p.Country,
                        Postcode = p.Postcode
                    };

                    db.Passenger.Add(passenger);
                }

                await db.SaveChangesAsync();

                return booking.BookingReference;
            }
        }        
    }
}
