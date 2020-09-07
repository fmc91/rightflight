using RightFlightBusinessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Navigation;

namespace RightFlight
{
    public class PageController
    {
        private NavigationWindow m_mainWindow;

        public PageController(NavigationWindow mainWindow)
        {
            m_mainWindow = mainWindow;
        }

        public void Home()
        {
            HomeViewModel viewModel = new HomeViewModel(this);

            HomePage homePage = new HomePage(viewModel);

            m_mainWindow.Navigate(homePage);
        }

        public void AddRoute()
        {
            AddRouteViewModel viewModel = new AddRouteViewModel(new CrudManager(), this);

            AddRoutePage addRoutePage = new AddRoutePage(viewModel);

            m_mainWindow.Navigate(addRoutePage);
        }

        public void AddFlight()
        {
            AddFlightViewModel viewModel = new AddFlightViewModel(new CrudManager(), this);

            AddFlightPage addFlightPage = new AddFlightPage(viewModel);

            m_mainWindow.Navigate(addFlightPage);
        }

        public void FlightSearch()
        {
            FlightSearchViewModel viewModel = new FlightSearchViewModel(new CrudManager(), this);

            FlightSearchPage flightSearchPage = new FlightSearchPage(viewModel);

            m_mainWindow.Navigate(flightSearchPage);
        }

        public void BookFlight(FlightInfo selectedFlight, int adults, int children, int infants)
        {
            BookFlightViewModel viewModel = new BookFlightViewModel(new CrudManager(), this, selectedFlight, adults, children, infants);

            BookFlightPage bookFlightPage = new BookFlightPage(viewModel);

            m_mainWindow.Navigate(bookFlightPage);
        }
    }
}
