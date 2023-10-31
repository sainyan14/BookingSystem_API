using BIM.Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task Add(Bookings booking);
        Task Update(Bookings booking);
        Task Delete(Bookings booking);
        Task<List<Bookings>> GetAll();
        //Task<List<Bookings>> GetMany();
        Task<Bookings> Get(int id);
    }
}
