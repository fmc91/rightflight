using System;
using System.Collections.Generic;
using System.Text;

namespace RightFlightBusinessLayer
{
    internal static class ArrivalTime
    {
        public static DateTime Calculate(DateTime departureTime, int flightDuration, string originTimeZoneKey, string destinationTimeZoneKey)
        {
            DateTime arrivalTimeInOriginTimeZone = departureTime + TimeSpan.FromMinutes(flightDuration);

            DateTime arrivalTimeInDestinationTimeZone =
                TimeZoneInfo.ConvertTimeBySystemTimeZoneId(arrivalTimeInOriginTimeZone, originTimeZoneKey, destinationTimeZoneKey);

            return arrivalTimeInDestinationTimeZone;
        }
    }
}
