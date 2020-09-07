using System;
using System.Collections.Generic;
using NUnit.Framework;
using RightFlightBusinessLayer;

namespace RightFlightTest
{
    public class ArrivalTimeTest
    {
        [Test]
        public void SameTimeZoneTest()
        {
            DateTime arrivalTime = ArrivalTime.Calculate(new DateTime(2020, 2, 1, 7, 30, 0), 130, "GMT Standard Time", "GMT Standard Time");

            Assert.AreEqual(new DateTime(2020, 2, 1, 9, 40, 0), arrivalTime);
        }

        [Test]
        public void SameTimeZoneNextDayArrivalTest()
        {
            DateTime arrivalTime = ArrivalTime.Calculate(new DateTime(2020, 2, 1, 23, 15, 0), 140, "W. Europe Standard Time", "W. Europe Standard Time");

            Assert.AreEqual(new DateTime(2020, 2, 2, 1, 35, 0), arrivalTime);
        }

        [Test]
        public void AheadTimeZoneTest()
        {
            DateTime arrivalTime = ArrivalTime.Calculate(new DateTime(2020, 2, 1, 7, 30, 0), 440, "W. Europe Standard Time", "Arabian Standard Time");

            Assert.AreEqual(new DateTime(2020, 2, 1, 17, 50, 0), arrivalTime);
        }

        [Test]
        public void BehindTimeZoneTest()
        {
            DateTime arrivalTime = ArrivalTime.Calculate(new DateTime(2020, 2, 1, 7, 30, 0), 510, "GMT Standard Time", "Eastern Standard Time");

            Assert.AreEqual(new DateTime(2020, 2, 1, 11, 0, 0), arrivalTime);
        }

        [Test]
        public void DstInOneTimeZoneTest()
        {
            DateTime arrivalTime = ArrivalTime.Calculate(new DateTime(2020, 7, 1, 7, 30, 0), 425, "W. Europe Standard Time", "Pakistan Standard Time");

            Assert.AreEqual(new DateTime(2020, 7, 1, 17, 35, 0), arrivalTime);
        }

        [Test]
        public void DstInBothTimeZonesTest()
        {
            DateTime arrivalTime = ArrivalTime.Calculate(new DateTime(2020, 7, 1, 7, 30, 0), 500, "GMT Standard Time", "Eastern Standard Time");

            Assert.AreEqual(new DateTime(2020, 7, 1, 10, 50, 0), arrivalTime);
        }
    }
}
