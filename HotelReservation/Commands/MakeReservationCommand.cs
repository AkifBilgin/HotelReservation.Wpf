using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace HotelReservation.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Hotel _hotel;
        private readonly NavigationService _navigationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel, NavigationService navigationService)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
            _navigationService = navigationService;
            _makeReservationViewModel.PropertyChanged += OnViewModelpropertychanged;
        }

        private void OnViewModelpropertychanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName== nameof(MakeReservationViewModel.Name) || e.PropertyName == nameof(MakeReservationViewModel.FloorNumber) ||
                e.PropertyName== nameof(MakeReservationViewModel.RoomNumber))
            { 
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (_makeReservationViewModel.Name != null && _makeReservationViewModel.FloorNumber > 0 && _makeReservationViewModel.RoomNumber>0)
            {
                 return base.CanExecute(parameter);
            }
            else
            {
                return false;
            }
      
        }

        public override void Execute(object? parameter)
        {
            Reservation reservation = new Reservation(new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.Name,_makeReservationViewModel.StartDate,_makeReservationViewModel.EndDate);


            try
            {
                _hotel.MakeReservation(reservation);
                MessageBox.Show("The reservation is completed succssesfully", "Succsses", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigationService.Navigate();

            }
            catch (ReservationConflictException)
            {

                MessageBox.Show("This room is already taken.", "Errormessage", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }
    }
}
