using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;

        public string RoomID => _reservation.RoomID?.ToString();
        public string Name =>_reservation.Name;
        public string StartTime => _reservation.StartTime.ToString("dd.MMM.YYY");
        public string EndTime => _reservation.EndTime.ToString("dd.MMM.YYY");
        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
 
}
