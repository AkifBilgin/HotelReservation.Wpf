using HotelReservation.DbContexts;
using HotelReservation.Dtos;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        private readonly HotelReservationDbContextFactory _dbContextFactory;

        public DatabaseReservationProvider(HotelReservationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsnyc()
        {
            using (HotelReservationDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ReservationDto> reservationDtos = await context.Reservations.ToListAsync();
               return reservationDtos.Select(r => new Reservation(new RoomID(r.FloorNumber, r.RoomNumber), r.Username, r.StartTime, r.EndTime));
            } 
        }
    }
}
