using System;
using System.Collections.Generic;
using System.Text;

namespace RightFlightBusinessLayer
{
    internal static class TicketPrice
    {
        public static List<TicketPriceInfo> Calculate(List<ClassPricingScheme> classPricingSchemes,
                                                              int adults, int children, int infants)
        {
            List<TicketPriceInfo> ticketPrices = new List<TicketPriceInfo>();

            foreach (ClassPricingScheme pricingScheme in classPricingSchemes)
            {
                float amount = adults * pricingScheme.AdultFare +
                              children * pricingScheme.ChildFare +
                              infants * pricingScheme.InfantFare;

                ticketPrices.Add(new TicketPriceInfo
                {
                    TravelClassCode = pricingScheme.TravelClassCode,
                    TravelClass = pricingScheme.TravelClassName,
                    Amount = amount
                });
            }

            return ticketPrices;
        }
    }
}
