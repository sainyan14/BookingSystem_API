using BIM.Booking.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Services
{
    public interface IBookingService
    {
        Task<BookingDto> GetBookingById(int id);
        Task AddBookingDto(AddBookingDto bookingDto);
        Task UpdateBookingDto(UpdateBookingDto bookingDto);
        Task DeleteBookingDto(int id);
        Task<List<BookingDto>> GetAllBookings();
    }
}
