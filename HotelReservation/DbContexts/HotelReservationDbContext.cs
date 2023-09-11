using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DbContexts
{
    public class HotelReservationDbContext : DbContext      
    {
        public HotelReservationDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<ReservationDto> Reservations { get; set; }     
    }
}
