using RightFlightBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace RightFlight
{
    public class FlightSearchViewModel : INotifyPropertyChanged
    {
        #region Private backing fields

        private List<CityInfo> m_originCitySearchResult;

        private List<CityInfo> m_destinationCitySearchResult;

        private List<FlightInfo> m_flightSearchResult;

        #endregion

        private CrudManager m_crudManager;

        private PageController m_pageController;

        public event PropertyChangedEventHandler PropertyChanged;

        public FlightSearchViewModel(CrudManager crudManager, PageController pageController)
        {
            m_crudManager = crudManager;
            m_pageController = pageController;

            OriginCitySearchResult = new List<CityInfo>();
            DestinationCitySearchResult = new List<CityInfo>();
            FlightSearchResult = new List<FlightInfo>();

            InitCommands();
        }

        public Command<object> HomeCommand { get; set; }

        public Command<object> FlightSearchCommand { get; set; }

        public Command<FlightInfo> BookCommand { get; set; }

        #region Auto-properties

        public string OriginCitySearchText { get; set; }

        public string DestinationCitySearchText { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public int Infants { get; set; }

        public CityInfo SelectedOriginCity { get; set; }

        public CityInfo SelectedDestinationCity { get; set; }

        #endregion

        #region INPC Properties

        public List<CityInfo> OriginCitySearchResult
        {
            get { return m_originCitySearchResult; }

            set
            {
                if (m_originCitySearchResult != value)
                {
                    m_originCitySearchResult = value;
                    NotifyOfPropertChanged();
                }
            }
        }

        public List<CityInfo> DestinationCitySearchResult
        {
            get { return m_destinationCitySearchResult; }

            set
            {
                if (m_destinationCitySearchResult != value)
                {
                    m_destinationCitySearchResult = value;
                    NotifyOfPropertChanged();
                }
            }
        }

        public List<FlightInfo> FlightSearchResult
        {
            get { return m_flightSearchResult; }

            set
            {
                if (m_flightSearchResult != value)
                {
                    m_flightSearchResult = value;
                    NotifyOfPropertChanged();
                }
            }
        }

        #endregion

        private void InitCommands()
        {
            FlightSearchCommand = new Command<object>(FlightSearch);
            BookCommand = new Command<FlightInfo>(Book);
            HomeCommand = new Command<object>(Home);
        }

        private void Home(object o)
        {
            m_pageController.Home();
        }

        public void OriginCitySearch()
        {
            if (OriginCitySearchText.Trim().Length < 3) return;

            OriginCitySearchResult = m_crudManager.CitySearch(OriginCitySearchText.Trim());
        }

        public void DestinationCitySearch()
        {
            if (DestinationCitySearchText.Trim().Length < 3) return;

            DestinationCitySearchResult = m_crudManager.CitySearch(DestinationCitySearchText.Trim());
        }

        private void FlightSearch(object o)
        {
            if (!ValidateFlightSearch()) return;

            FlightSearchResult = m_crudManager.FlightSearch(SelectedOriginCity.IataCityCode, SelectedDestinationCity.IataCityCode, Adults, Children, Infants);
        }

        private void Book(FlightInfo flightSearchResult)
        {
            m_pageController.BookFlight(flightSearchResult, Adults, Children, Infants);
        }

        private bool ValidateFlightSearch()
        {
            if (SelectedOriginCity == null)
            {
                MessageBox.Show("Please select a location to fly from.", "Error");
                return false;
            }

            if (SelectedDestinationCity == null)
            {
                MessageBox.Show("Please select a location to fly to.", "Error");
                return false;
            }

            if (Adults + Children + Infants == 0)
            {
                MessageBox.Show("A booking must include at least one person.", "Error");
                return false;
            }

            return true;
        }

        private void NotifyOfPropertChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
