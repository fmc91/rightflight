using RightFlightEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RightFlightBusinessLayer
{
    internal static class BookingReference
    {
        private static readonly char[] m_allowableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        public static string Generate()
        {
            string bookingReference = null;

            char[] chars = new char[6];

            Random random = new Random();

            do
            {
                for (int i = 0; i < chars.Length; ++i)
                    chars[i] = m_allowableChars[random.Next(m_allowableChars.Length)];

                bookingReference = new string(chars);

            } while (AlreadyExists(bookingReference));

            return bookingReference;
        }

        private static bool AlreadyExists(string bookingReference)
        {
            using (FlightReservationContext db = new FlightReservationContext())
            {
                var query =
                    from b in db.Booking
                    where b.BookingReference == bookingReference
                    select b;

                return query.Any();
            }
        }
    }
}
