using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using RightFlightBusinessLayer;
using RightFlightEntityModel;

namespace RightFlight
{
    public class AddFlightViewModel : INotifyPropertyChanged
    {
        #region Private Backing Fields

        private AirlineInfo m_selectedAirline;

        private AirportInfo m_selectedAirport;

        private List<AirlineInfo> m_airlineSearchResult;

        private List<AirportInfo> m_airportSearchResult;

        private List<RouteInfo> m_routeSearchResult;

        private List<RouteAircraftInfo> m_routeAircraftSearchResult;

        private RouteInfo m_selectedRoute;

        #endregion

        private CrudManager m_crudManager;

        private PageController m_pageController;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddFlightViewModel(CrudManager crudManager, PageController pageController)
        {
            m_crudManager = crudManager;
            m_pageController = pageController;

            AirlineSearchResult = new List<AirlineInfo>();
            AirportSearchResult = new List<AirportInfo>();
            RouteSearchResult = new List<RouteInfo>();

            SelectedDate = DateTime.Today;

            InitCommands();
        }

        public Command<object> ConfirmCommand { get; set; }

        public Command<object> CancelCommand { get; set; }

        #region Auto-Properties

        public string AirlineSearchText { get; set; }

        public string AirportSearchText { get; set; }

        public RouteAircraftInfo SelectedRouteAircraft { get; set; }

        public DateTime SelectedDate { get; set; }

        public int? DepartureTimeHours { get; set; }

        public int? DepartureTimeMinutes { get; set; }

        public string FlightNumber { get; set; }

        #endregion

        #region Call-Method-On-Change Properties

        public AirlineInfo SelectedAirline
        {
            get { return m_selectedAirline; }

            set
            {
                if (m_selectedAirline != value)
                {
                    m_selectedAirline = value;
                    OnSelectedAirlineChanged();
                }
            }
        }

        public AirportInfo SelectedAirport
        {
            get { return m_selectedAirport; }

            set
            {
                if (m_selectedAirport != value)
                {
                    m_selectedAirport = value;
                    OnSelectedAirportChanged();
                }
            }
        }

        public RouteInfo SelectedRoute
        {
            get { return m_selectedRoute; }

            set
            {
                if (m_selectedRoute != value)
                {
                    m_selectedRoute = value;
                    OnSelectedRouteChanged();
                }
            }
        }

        #endregion

        #region INPC Properties

        public List<AirlineInfo> AirlineSearchResult
        {
            get { return m_airlineSearchResult; }

            set
            {
                if (m_airlineSearchResult != value)
                {
                    m_airlineSearchResult = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public List<AirportInfo> AirportSearchResult
        {
            get { return m_airportSearchResult; }

            set
            {
                if (m_airportSearchResult != value)
                {
                    m_airportSearchResult = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public List<RouteInfo> RouteSearchResult
        {
            get { return m_routeSearchResult; }

            set
            {
                if (m_routeSearchResult != value)
                {
                    m_routeSearchResult = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public List<RouteAircraftInfo> RouteAircraftSearchResult
        {
            get { return m_routeAircraftSearchResult; }

            set
            {
                if (m_routeAircraftSearchResult != value)
                {
                    m_routeAircraftSearchResult = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        #endregion

        private void InitCommands()
        {
            ConfirmCommand = new Command<object>(Confirm);

            CancelCommand = new Command<object>(Cancel);
        }

        public void AirlineSearch()
        {
            if (AirlineSearchText.Trim().Length < 3) return;

            AirlineSearchResult = m_crudManager.AirlineSearch(AirlineSearchText.Trim());
        }

        public void AirportSearch()
        {
            if (AirportSearchText.Trim().Length < 3) return;

            AirportSearchResult = m_crudManager.AirportSearch(AirportSearchText.Trim());
        }

        private void RouteSearch()
        {
            if (SelectedAirline == null)      
                RouteSearchResult = new List<RouteInfo>();    
            else if (SelectedAirport == null)
                RouteSearchResult = m_crudManager.GetRoutes(SelectedAirline.IataAirlineCode);
            else
                RouteSearchResult = m_crudManager.GetRoutes(SelectedAirline.IataAirlineCode, SelectedAirport.IataAirportCode);
        }

        private void RouteAircraftSearch()
        {
            if (SelectedRoute == null)
                RouteAircraftSearchResult = new List<RouteAircraftInfo>();
            else
                RouteAircraftSearchResult = m_crudManager.GetRouteAircraftInfoByRouteId(SelectedRoute.RouteId);
        }

        private void Confirm(object o)
        {
            if (!ValidateConfirm()) return;

            DateTime scheduledDeparture = SelectedDate.AddHours(DepartureTimeHours.Value).AddMinutes(DepartureTimeMinutes.Value);

            m_crudManager.AddFlight(SelectedRouteAircraft.RouteAircraftId, FlightNumber, scheduledDeparture);

            MessageBoxResult result = MessageBox.Show("Flight added successfully. Add another?", "Success", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                m_pageController.AddFlight();
            else
                m_pageController.Home();
        }

        private void Cancel(object o)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                m_pageController.Home();
        }

        private bool ValidateConfirm()
        {
            if (SelectedRouteAircraft == null)
            {
                MessageBox.Show("Please select an aircraft.", "Aircraft Required");
                return false;
            }

            if (String.IsNullOrWhiteSpace(FlightNumber))
            {
                MessageBox.Show("Please enter a flight number.", "Flight number required");
                return false;
            }

            if (SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please select a date in the future.", "Invalid date");
                return false;
            }

            if (DepartureTimeHours == null)
            {
                MessageBox.Show("Please enter a departure time.", "Departure time required");
                return false;
            }

            if (DepartureTimeMinutes == null)
            {
                MessageBox.Show("Please enter a departure time.", "Departure time required");
                return false;
            }

            if (DepartureTimeHours.Value > 23)
            {
                MessageBox.Show("Hours cannot be greater than 23.", "Invalid time");
                return false;
            }

            if (DepartureTimeMinutes.Value > 59)
            {
                MessageBox.Show("Minutes cannot be greater than 59.", "Invalid time");
                return false;
            }

            return true;
        }

        private void OnSelectedAirlineChanged()
        {
            RouteSearch();
        }

        private void OnSelectedAirportChanged()
        {
            RouteSearch();
        }

        private void OnSelectedRouteChanged()
        {
            RouteAircraftSearch();
        }

        public void NotifyOfPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
