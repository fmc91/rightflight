using System;
using System.Collections.Generic;
using RightFlightEntityModel;
using RightFlightBusinessLayer;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RightFlight
{
    public class AddRouteViewModel : INotifyPropertyChanged
    {
        #region Private Backing Fields

        private UiState m_uiState;

        private AircraftInfo m_selectedAircraft;

        private int? m_durationHours;

        private int? m_durationMinutes;

        private float? m_adultFare;

        private float? m_childFare;

        private float? m_infantFare;

        private TravelClassInfo m_selectedTravelClass;

        private List<TravelClassInfo> m_travelClasses;

        private List<AirlineInfo> m_airlineSearchResult;

        private List<AirportInfo> m_originSearchResult;

        private List<AirportInfo> m_destinationSearchResult;

        private List<AircraftInfo> m_aircraftSearchResult;

        #endregion

        private CrudManager m_crudManager;

        private PageController m_pageController;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddRouteViewModel(CrudManager crudManager, PageController pageController)
        {
            m_crudManager = crudManager;
            m_pageController = pageController;

            AirlineSearchResult = new List<AirlineInfo>();
            OriginSearchResult = new List<AirportInfo>();
            DestinationSearchResult = new List<AirportInfo>();
            AircraftSearchResult = new List<AircraftInfo>();

            FlightDurations = new ObservableCollection<FlightDuration>();
            ClassPricingSchemes = new ObservableCollection<ClassPricingScheme>();

            TravelClasses = new List<TravelClassInfo>();

            UiState = UiState.Normal;

            InitCommands();

            GetTravelClasses();
        }

        #region Commands

        public Command<object> AddFlightDurationCommand { get; set; }

        public Command<FlightDuration> RemoveFlightDurationCommand { get; set; }

        public Command<object> AddPricingSchemeCommand { get; set; }

        public Command<ClassPricingScheme> RemovePricingSchemeCommand { get; set; }

        public AsyncCommand<object> ConfirmCommand { get; set; }

        public Command<object> CancelCommand { get; set; }

        #endregion

        #region Auto-Properties

        public string AirlineSearchText { get; set; }

        public string OriginSearchText { get; set; }

        public string DestinationSearchText { get; set; }

        public string AircraftSearchText { get; set; }

        public AirlineInfo SelectedAirline { get; set; }

        public AirportInfo SelectedOrigin { get; set; }

        public AirportInfo SelectedDestination { get; set; }        

        public ObservableCollection<FlightDuration> FlightDurations { get; set; }

        public ObservableCollection<ClassPricingScheme> ClassPricingSchemes { get; set; }

        #endregion

        #region INPC Properties

        public UiState UiState
        {
            get { return m_uiState; }

            set
            {
                if (m_uiState != value)
                {
                    m_uiState = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public AircraftInfo SelectedAircraft
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

        public int? DurationHours
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

        public int? DurationMinutes
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

        public float? AdultFare
        {
            get { return m_adultFare; }

            set
            {
                if (m_adultFare != value)
                {
                    m_adultFare = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public float? ChildFare
        {
            get { return m_childFare; }

            set
            {
                if (m_childFare != value)
                {
                    m_childFare = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public float? InfantFare
        {
            get { return m_infantFare; }

            set
            {
                if (m_infantFare != value)
                {
                    m_infantFare = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        public List<TravelClassInfo> TravelClasses
        {
            get { return m_travelClasses; }

            set
            {
                if (m_travelClasses != value)
                {
                    m_travelClasses = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

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

        public List<AirportInfo> OriginSearchResult
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

        public List<AirportInfo> DestinationSearchResult
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

        public List<AircraftInfo> AircraftSearchResult
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

        public TravelClassInfo SelectedTravelClass
        {
            get { return m_selectedTravelClass; }

            set
            {
                if (m_selectedTravelClass != value)
                {
                    m_selectedTravelClass = value;
                    NotifyOfPropertyChanged();
                }
            }
        }

        #endregion

        private void InitCommands()
        {
            AddFlightDurationCommand = new Command<object>(AddFlightDuration);
            AddPricingSchemeCommand = new Command<object>(AddPricingScheme);
            RemoveFlightDurationCommand = new Command<FlightDuration>(RemoveFlightDuration);
            RemovePricingSchemeCommand = new Command<ClassPricingScheme>(RemovePricingScheme);
            ConfirmCommand = new AsyncCommand<object>(Confirm);
            CancelCommand = new Command<object>(Cancel);
        }

        private async Task GetTravelClasses()
        {
            TravelClasses = new List<TravelClassInfo>(await m_crudManager.GetTravelClasses());
        }

        public async Task OriginSearch()
        {
            if (OriginSearchText.Length < 3) return;

            OriginSearchResult = await m_crudManager.AirportSearch(OriginSearchText);
        }

        public async Task AirlineSearch()
        {
            if (AirlineSearchText.Length < 3) return;

            AirlineSearchResult = await m_crudManager.AirlineSearch(AirlineSearchText);
        }

        public async Task DestinationSearch()
        {
            if (DestinationSearchText.Length < 3) return;

            DestinationSearchResult = await m_crudManager.AirportSearch(DestinationSearchText);
        }

        public async Task AircraftSearch()
        {
            if (AircraftSearchText.Length < 3) return;

            AircraftSearchResult = await m_crudManager.AircraftSearch(AircraftSearchText);
        }

        public void AddFlightDuration(object o)
        {
            if (!ValidateAddFlightDuration()) return;

            FlightDuration flightDuration = new FlightDuration
            {
                Aircraft = SelectedAircraft,
                DurationHours = DurationHours.Value,
                DurationMinutes = DurationMinutes.Value
            };

            FlightDurations.Add(flightDuration);

            SelectedAircraft = null;
            DurationHours = null;
            DurationMinutes = null;
        }

        public void AddPricingScheme(object o)
        {
            if (!ValidateAddPricingScheme()) return;

            ClassPricingScheme pricingScheme = new ClassPricingScheme
            {
                TravelClassCode = SelectedTravelClass.TravelClassCode,
                TravelClassName = SelectedTravelClass.Name,
                AdultFare = AdultFare.Value,
                ChildFare = ChildFare.Value,
                InfantFare = InfantFare.Value
            };

            ClassPricingSchemes.Add(pricingScheme);

            SelectedTravelClass = null;
            AdultFare = null;
            ChildFare = null;
            InfantFare = null;
        }

        public void RemoveFlightDuration(FlightDuration flightDuration)
        {
            FlightDurations.Remove(flightDuration);
        }

        public void RemovePricingScheme(ClassPricingScheme pricingScheme)
        {
            ClassPricingSchemes.Remove(pricingScheme);
        }

        public async Task Confirm(object o)
        {
            if (!ValidateConfirm()) return;

            try
            {
                UiState = UiState.Wait;

                await m_crudManager.AddRoute(SelectedAirline.IataAirlineCode, SelectedOrigin.IataAirportCode, SelectedDestination.IataAirportCode,
                                       FlightDurations.ToList(), ClassPricingSchemes.ToList());

                UiState = UiState.Normal;

                MessageBoxResult result = MessageBox.Show("Route added successfully. Add another?", "Success", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                    m_pageController.AddRoute();
                else
                    m_pageController.Home();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Cancel(object o)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                m_pageController.Home();
        }

        private bool ValidateAddFlightDuration()
        {
            if (SelectedAircraft == null)
            {
                MessageBox.Show("Please select an aircraft to add.", "Aircraft required");
                return false;
            }

            if (FlightDurations.Any(fd => fd.Aircraft.IcaoTypeCode == SelectedAircraft.IcaoTypeCode))
            {
                MessageBox.Show("You can't add the same aircraft twice.", "Invalid input");
                return false;
            }

            if (DurationHours == null)
            {
                MessageBox.Show("Please enter a value for hours.", "Value required");
                return false;
            }

            if (DurationMinutes == null)
            {
                MessageBox.Show("Please enter a value for minutes.", "Value required");
                return false;
            }

            if (DurationMinutes > 59)
            {
                MessageBox.Show("Minutes cannot be greater than 59.", "Invalid input");
                return false;
            }

            return true;
        }

        private bool ValidateAddPricingScheme()
        {
            if (SelectedTravelClass == null)
            {
                MessageBox.Show("Please select a travel class.", "Travel class required");
                return false;
            }

            if (ClassPricingSchemes.Any(ps => ps.TravelClassCode == SelectedTravelClass.TravelClassCode))
            {
                MessageBox.Show("You cannot add a pricing scheme for the same travel class more than once.", "Invalid input");
                return false;
            }

            if (AdultFare == null)
            {
                MessageBox.Show("Please enter an adult fare.", "Adult fare required");
                return false;
            }

            if (ChildFare == null)
            {
                MessageBox.Show("Please enter a child fare.", "Child fare required");
                return false;
            }

            if (InfantFare == null)
            {
                MessageBox.Show("Please enter an infant fare.", "Infant fare required");
                return false;
            }

            return true;
        }

        private bool ValidateConfirm()
        {
            if (SelectedAirline == null)
            {
                MessageBox.Show("Please select an airline.", "Airline required");
                return false;
            }

            if (SelectedOrigin == null)
            {
                MessageBox.Show("Please select a point of origin.", "Origin required");
                return false;
            }

            if (SelectedDestination == null)
            {
                MessageBox.Show("Please select a destination.", "Destination required");
                return false;
            }

            if (FlightDurations.Count == 0)
            {
                MessageBox.Show("At least one aircraft must fly the route.", "Aircraft required");
                return false;
            }

            if (ClassPricingSchemes.Count == 0)
            {
                MessageBox.Show("At least one travel class must be available on the route.", "Travel class required");
                return false;
            }

            if (SelectedOrigin.IataAirportCode == SelectedDestination.IataAirportCode)
            {
                MessageBox.Show("Origin and destination airport cannot be the same.", "Invalid input");
                return false;
            }

            return true;
        }

        public void NotifyOfPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
