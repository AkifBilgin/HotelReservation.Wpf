using HotelReservation.Commands;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelReservation.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        private readonly Hotel _hotel;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
      
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(Hotel hotel, NavigationService navigationService)
        {
            _hotel = hotel;
            MakeReservationCommand = new NavigateCommand(navigationService);
            _reservations = new ObservableCollection<ReservationViewModel>();

            UpdateReservations();
           
        }

        private void UpdateReservations()
        {
          _reservations.Clear();
            foreach (var item in _hotel.GetReservation())
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(item);
                _reservations.Add(reservationViewModel);
            }
        }
    }
}
