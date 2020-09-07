using System;
using Newtonsoft.Json;
using NUnit.Framework;
using RightFlightBusinessLayer;
using RightFlightEntityModel;
using System.Collections.Generic;
using System.Linq;

namespace RightFlightTest
{
    public class CrudTest
    {
        private CrudManager m_crudManager;

        [SetUp]
        public void Setup()
        {
            m_crudManager = new CrudManager();
        }

        [Test]
        public void AddRouteTest()
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {

                List<ClassPricingScheme> pricingScheme = new List<ClassPricingScheme>
                {
                    new ClassPricingScheme { TravelClassCode = "E", TravelClassName = "Economy Class", AdultFare = 200, ChildFare = 160, InfantFare = 40 },
                    new ClassPricingScheme { TravelClassCode = "B", TravelClassName = "Business Class", AdultFare = 1000, ChildFare = 800, InfantFare = 200 }
                };

                List<FlightDuration> flightDurations = new List<FlightDuration>
                {
                    new FlightDuration { Aircraft = new AircraftInfo { IcaoTypeCode = "A320", Model = "Airbus A320" }, DurationHours = 1, DurationMinutes = 45 },
                    new FlightDuration { Aircraft = new AircraftInfo { IcaoTypeCode = "B733", Model = "Boeing 737-300" }, DurationHours = 1, DurationMinutes = 50 }
                };

                m_crudManager.AddRoute("BA", "BHX", "ARN", flightDurations, pricingScheme);

                var routeQuery =
                    from r in db.Route
                    where r.AirlineCode == "BA" &&
                            r.OriginAirportCode == "BHX" &&
                            r.DestinationAirportCode == "ARN"
                    select r;

                Assert.DoesNotThrow(() => routeQuery.Single());

                Route selectedRoute = routeQuery.Single();

                List<ClassPricingScheme> selectedRoutePricingScheme = JsonConvert.DeserializeObject<List<ClassPricingScheme>>(selectedRoute.PricingScheme);

                Assert.AreEqual(2, selectedRoutePricingScheme.Count);

                Assert.AreEqual("E", selectedRoutePricingScheme[0].TravelClassCode);
                Assert.AreEqual(200, selectedRoutePricingScheme[0].AdultFare);
                Assert.AreEqual(160, selectedRoutePricingScheme[0].ChildFare);
                Assert.AreEqual(40, selectedRoutePricingScheme[0].InfantFare);

                Assert.AreEqual("B", selectedRoutePricingScheme[1].TravelClassCode);
                Assert.AreEqual(1000, selectedRoutePricingScheme[1].AdultFare);
                Assert.AreEqual(800, selectedRoutePricingScheme[1].ChildFare);
                Assert.AreEqual(200, selectedRoutePricingScheme[1].InfantFare);

                var routeAircraftQuery =
                    from r in db.Route
                    join ra in db.RouteAircraft on r.RouteId equals ra.RouteId
                    where r.AirlineCode == "BA" &&
                            r.OriginAirportCode == "BHX" &&
                            r.DestinationAirportCode == "ARN"
                    select ra;

                List<RouteAircraft> selectedRouteAircraft = routeAircraftQuery.ToList();

                Assert.AreEqual(2, selectedRouteAircraft.Count);

                Assert.IsTrue(selectedRouteAircraft.Exists(ra => ra.IcaoTypeCode == "A320" && ra.FlightDuration == 105));
                Assert.IsTrue(selectedRouteAircraft.Exists(ra => ra.IcaoTypeCode == "B733" && ra.FlightDuration == 110));

                db.RouteAircraft.RemoveRange(selectedRouteAircraft);

                db.Route.Remove(selectedRoute);

                db.SaveChanges();
            }
        }

        [Test]
        public void AddFlightTest()
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {

                List<ClassPricingScheme> pricingScheme = new List<ClassPricingScheme>
                {
                    new ClassPricingScheme { TravelClassCode = "E", TravelClassName = "Economy Class", AdultFare = 200, ChildFare = 160, InfantFare = 40 },
                    new ClassPricingScheme { TravelClassCode = "B", TravelClassName = "Business Class", AdultFare = 1000, ChildFare = 800, InfantFare = 200 }
                };

                Route newRoute = new Route
                {
                    AirlineCode = "BA",
                    OriginAirportCode = "BHX",
                    DestinationAirportCode = "ARN",
                    PricingScheme = JsonConvert.SerializeObject(pricingScheme)
                };

                db.Route.Add(newRoute);
                db.SaveChanges();

                RouteAircraft newRouteAircraft = new RouteAircraft
                {
                    RouteId = newRoute.RouteId,
                    IcaoTypeCode = "A320",
                    FlightDuration = 105
                };

                db.RouteAircraft.Add(newRouteAircraft);
                db.SaveChanges();

                m_crudManager.AddFlight(newRouteAircraft.RouteAircraftId, "BA188", new DateTime(2020, 9, 6, 15, 30, 0));

                var query =
                    from f in db.Flight
                    join ra in db.RouteAircraft on f.RouteAircraftId equals ra.RouteAircraftId
                    join r in db.Route on ra.RouteId equals r.RouteId
                    where r.AirlineCode == "BA" &&
                          r.OriginAirportCode == "BHX" &&
                          r.DestinationAirportCode == "ARN"
                    select f;

                List<Flight> selectedFlights = query.ToList();

                Assert.IsTrue(selectedFlights.Exists(f => f.RouteAircraftId == newRouteAircraft.RouteAircraftId &&
                                                     f.FlightNumber == "BA188" && f.ScheduledDeparture == new DateTime(2020, 9, 6, 15, 30, 0)));

                Flight flightToDelete = selectedFlights.Find(f => f.RouteAircraftId == newRouteAircraft.RouteAircraftId &&
                                                             f.FlightNumber == "BA188" && f.ScheduledDeparture == new DateTime(2020, 9, 6, 15, 30, 0));

                if (flightToDelete != null)
                    db.Flight.Remove(flightToDelete);

                db.RouteAircraft.Remove(newRouteAircraft);
                db.Route.Remove(newRoute);

                db.SaveChanges();
            }
        }
    }
}