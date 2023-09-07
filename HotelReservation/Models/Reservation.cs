using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class Reservation
    {
        public Reservation(RoomID roomID, string name, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }

        public RoomID RoomID { get; }
        public string Name { get;  }
        public DateTime StartTime { get; }
        public DateTime EndTime { get;}
        public TimeSpan Length => EndTime.Subtract(StartTime);

        internal bool Conflicts(Reservation reservation)
        {
          if(!reservation.RoomID.Equals(RoomID))
            {
                return false;
            }
            return reservation.StartTime < EndTime && reservation.EndTime> StartTime;
        }
    }
}
