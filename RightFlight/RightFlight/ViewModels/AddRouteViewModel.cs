using System;
using System.Collections.Generic;
using RightFlightEntityModel;
using RightFlightBusinessLayer;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.ObjectModel;

namespace RightFlight
{
    public class AddRouteViewModel : INotifyPropertyChanged
    {
        private Aircraft m_selectedAircraft;

        private int m_durationHours;

        private int m_durationMinutes;

        private List<Airline> m_airlineSearchResult;

        private List<Airport> m_originSearchResult;

        private List<Airport> m_destinationSearchResult;

        private List<Aircraft> m_aircraftSearchResult;

        private CrudManager m_crudManager;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddRouteViewModel()
        {
            m_crudManager = new CrudManager();

            AirlineSearchResult = new List<Airline>();
            OriginSearchResult = new List<Airport>();
            DestinationSearchResult = new List<Airport>();
            AircraftSearchResult = new List<Aircraft>();

            AircraftFlyingRoute = new ObservableCollection<AircraftDuration>();

            AddAircraftCommand = new Command<object>(AddAircraft);
        }

        public Command<object> AddAircraftCommand { get; set; }

        public string AirlineSearchText { get; set; }

        public string OriginSearchText { get; set; }

        public string DestinationSearchText { get; set; }

        public string AircraftSearchText { get; set; }

        public Airline SelectedAirline { get; set; }

        public Airport SelectedOrigin { get; set; }

        public Airport SelectedDestination { get; set; }

        public ObservableCollection<AircraftDuration> AircraftFlyingRoute { get; set; }

        public Aircraft SelectedAircraft
        {
            get { return m_selectedAircraft; }

            set
            {
                if (m_selectedAircraft != value)
                {
                    m_selectedAircraft = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public int DurationHours
        {
            get { return m_durationHours; }

            set
            {
                if (m_durationHours != value)
                {
                    m_durationHours = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public int DurationMinutes
        {
            get { return m_durationMinutes; }

            set
            {
                if (m_durationMinutes != value)
                {
                    m_durationMinutes = value;
                    NotifyOfPropertyChanged();
                }    
            }
        }

        public List<Airline> AirlineSearchResult
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

        public List<Airport> OriginSearchResult
        {
            get { return m_originSearchResult; }

            set
            {
                if (m_originSearchResult != value)
                {
                    m_originSearchResult = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public List<Airport> DestinationSearchResult
        {
            get { return m_destinationSearchResult; }

            set
            {
                if (m_destinationSearchResult != value)
                {
                    m_destinationSearchResult = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public List<Aircraft> AircraftSearchResult
        {
            get { return m_aircraftSearchResult; }

            set
            {
                if (m_aircraftSearchResult != value)
                {
                    m_aircraftSearchResult = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public void OriginSearch()
        {
            if (OriginSearchText.Length < 3) return;

            OriginSearchResult = m_crudManager.AirportSearch(OriginSearchText);
        }

        public void AirlineSearch()
        {
            if (AirlineSearchText.Length < 3) return;

            AirlineSearchResult = m_crudManager.AirlineSearch(AirlineSearchText);
        }

        public void DestinationSearch()
        {
            if (DestinationSearchText.Length < 3) return;

            DestinationSearchResult = m_crudManager.AirportSearch(DestinationSearchText);
        }

        public void AircraftSearch()
        {
            if (AircraftSearchText.Length < 3) return;

            AircraftSearchResult = m_crudManager.AircraftSearch(AircraftSearchText);
        }

        public void AddAircraft(object o)
        {
            AircraftDuration aircraftDuration = new AircraftDuration
            {
                Aircraft = SelectedAircraft,
                DurationHours = DurationHours,
                DurationMinutes = DurationMinutes
            };

            AircraftFlyingRoute.Add(aircraftDuration);

            SelectedAircraft = null;
            DurationHours = 0;
            DurationMinutes = 0;
        }

        public void NotifyOfPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
