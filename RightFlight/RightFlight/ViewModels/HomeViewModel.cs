using RightFlightBusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightFlight
{
    public class HomeViewModel
    {
        private PageController m_pageController;

        public HomeViewModel(PageController pageController)
        {
            m_pageController = pageController;

            InitCommands();
        }
        
        public Command<object> SearchForFlightsCommand { get; set; }

        public Command<object> AddRouteCommand { get; set; }

        public Command<object> AddFlightCommand { get; set; }

        private void InitCommands()
        {
            SearchForFlightsCommand = new Command<object>(SearchForFlights);

            AddRouteCommand = new Command<object>(AddRoute);

            AddFlightCommand = new Command<object>(AddFlight);
        }

        private void SearchForFlights(object o)
        {
            m_pageController.FlightSearch();
        }

        private void AddRoute(object o)
        {
            m_pageController.AddRoute();
        }

        private void AddFlight(object o)
        {
            m_pageController.AddFlight();
        }
    }
}
