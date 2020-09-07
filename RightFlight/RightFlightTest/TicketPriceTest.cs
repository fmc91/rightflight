using System;
using System.Collections.Generic;
using RightFlightBusinessLayer;
using NUnit.Framework;

namespace RightFlightTest
{
    public class TicketPriceTest
    {
        List<ClassPricingScheme> m_pricingSchemes;

        [SetUp]
        public void Setup()
        {
            m_pricingSchemes = new List<ClassPricingScheme>
            {
                new ClassPricingScheme { TravelClassCode = "E", TravelClassName = "Economy Class", AdultFare = 150, ChildFare = 120, InfantFare = 30 },
                new ClassPricingScheme { TravelClassCode = "B", TravelClassName = "Business Class", AdultFare = 700, ChildFare = 560, InfantFare = 140 },
                new ClassPricingScheme { TravelClassCode = "F", TravelClassName = "First Class", AdultFare = 1200, ChildFare = 960, InfantFare = 240 }
            };
        }

        [TestCase(1, 0, 0, 150, 700, 1200)]
        [TestCase(0, 1, 0, 120, 560, 960)]
        [TestCase(0, 0, 1, 30, 140, 240)]
        [TestCase(2, 0, 0, 300, 1400, 2400)]
        [TestCase(2, 1, 0, 420, 1960, 3360)]
        [TestCase(3, 2, 1, 720, 3360, 5760)]
        public void Test(int adults, int children, int infants, float expectedEconomyPrice, float expectedBusinessPrice, float expectedFirstPrice)
        {
            List<TicketPriceInfo> ticketPrices = TicketPrice.Calculate(m_pricingSchemes, adults, children, infants);

            Assert.AreEqual("E", ticketPrices[0].TravelClassCode);
            Assert.AreEqual("Economy Class", ticketPrices[0].TravelClass);
            Assert.AreEqual(expectedEconomyPrice, ticketPrices[0].Amount);

            Assert.AreEqual("B", ticketPrices[1].TravelClassCode);
            Assert.AreEqual("Business Class", ticketPrices[1].TravelClass);            
            Assert.AreEqual(expectedBusinessPrice, ticketPrices[1].Amount);

            Assert.AreEqual("F", ticketPrices[2].TravelClassCode);
            Assert.AreEqual("First Class", ticketPrices[2].TravelClass);            
            Assert.AreEqual(expectedFirstPrice, ticketPrices[2].Amount);
        }
    }
}
