using RightFlightBusinessLayer;
using System;
using System.Collections.Generic;
using System.Windows;

namespace RightFlight
{
    public class BookFlightViewModel
    {
        private CrudManager m_crudManager;

        private PageController m_pageController;

        public BookFlightViewModel(CrudManager crudManager, PageController pageController, FlightInfo selectedFlight, int adults, int children, int infants)
        {
            m_crudManager = crudManager;
            m_pageController = pageController;

            SelectedFlight = selectedFlight;
            Adults = adults;
            Children = children;
            Infants = infants;

            PassengerInfo = new List<PassengerInfo>();

            for (int i = 1; i <= Adults + Children + Infants; ++i)
                PassengerInfo.Add(new PassengerInfo { Index = i, DateOfBirth = DateTime.Today });            

            Nationalities = m_crudManager.GetNationalities();

            SelectedTicketType = SelectedFlight.TicketPrices[0];

            InitCommands();
        }

        #region Commands

        public Command<object> ConfirmCommand { get; set; }

        public Command<object> CancelCommand { get; set; }

        #endregion

        #region Auto-Properties

        public int Adults { get; set; }

        public int Children { get; set; }

        public int Infants { get; set; }

        public FlightInfo SelectedFlight { get; set; }

        public TicketPriceInfo SelectedTicketType { get; set; }

        public List<PassengerInfo> PassengerInfo { get; set; }

        public List<NationalityInfo> Nationalities { get; set; }

        #endregion

        private void InitCommands()
        {
            ConfirmCommand = new Command<object>(Confirm);

            CancelCommand = new Command<object>(Cancel);
        }

        private void Confirm(object o)
        {
            if (!ValidateConfirm()) return;

            if (!ValidateAges()) return;

            string bookingReference = m_crudManager.CreateBooking(SelectedFlight.FlightId, SelectedTicketType.TravelClassCode, SelectedTicketType.Amount, PassengerInfo);

            MessageBox.Show($"Your booking was successful. Your booking reference is {bookingReference}.", "Success");

            m_pageController.Home();
        }

        private void Cancel(object o)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                m_pageController.FlightSearch();
        }

        private bool ValidateConfirm()
        {
            foreach (PassengerInfo passenger in PassengerInfo)
            {
                if (String.IsNullOrWhiteSpace(passenger.FirstName))
                {
                    MessageBox.Show($"Please enter first name for passenger {passenger.Index}.", "First name required");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(passenger.LastName))
                {
                    MessageBox.Show($"Please enter last name for passenger {passenger.Index}.", "Last name required");
                    return false;
                }

                if (passenger.NationalityId == -1)
                {
                    MessageBox.Show($"Please enter nationality for passenger {passenger.Index}.", "Nationality required");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(passenger.Address))
                {
                    MessageBox.Show($"Please enter address for passenger {passenger.Index}.", "Address required");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(passenger.City))
                {
                    MessageBox.Show($"Please enter city for passenger {passenger.Index}.", "City required");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(passenger.Country))
                {
                    MessageBox.Show($"Please enter country for passenger {passenger.Index}.", "Country required");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(passenger.Postcode))
                {
                    MessageBox.Show($"Please enter postcode for passenger {passenger.Index}.", "Postcode required");
                    return false;
                }

                if (passenger.DateOfBirth > DateTime.Today)
                {
                    MessageBox.Show($"Date of birth must be in the past. Please enter a valid date of birth for passenger {passenger.Index}.", "Invalid date of birth");
                    return false;
                }
            }

            return true;
        }

        private bool ValidateAges()
        {
            int actualAdults = 0;
            int actualChildren = 0;
            int actualInfants = 0;

            foreach (PassengerInfo passenger in PassengerInfo)
            {
                int age = CalculateAge(passenger.DateOfBirth);

                if (age < 2)
                    ++actualInfants;
                else if (age < 12)
                    ++actualChildren;
                else
                    ++actualAdults;
            }

            if (actualAdults != Adults)
            {
                MessageBox.Show("The number of adults in your booking does not match the number of adults in your ticket selection. An adult is a person who has " +
                    "reached their twelfth birthday at the date of travel. Please go back acnd change your ticket selection.", "Error");
                return false;
            }

            if (actualChildren != Children)
            {
                MessageBox.Show("The number of children in your booking does not match the number of children in your ticket selection. A child is a person who has " +
                    "reached their second birthday at the date of travel, but not their twelfth birthday. Please go back acnd change your ticket selection.", "Error");
                return false;
            }

            return true;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            return (int)Math.Floor((SelectedFlight.DepartureTime.Date - dateOfBirth).TotalDays / 365.25);
        }
    }
}
