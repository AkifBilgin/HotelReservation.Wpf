using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class Hotel
    {
       private readonly ReservationBook _reservationsBook;

        public string Name { get;  }
        public Hotel(string name)
        {
            _reservationsBook = new ReservationBook();
            Name = name;    
        }

        public IEnumerable<Reservation> GetReservation()
        {
            return _reservationsBook.GetReservations();
        }

        public void MakeReservation(Reservation reservation)
        {
            _reservationsBook.AddReservation(reservation);
        }
    }
}
