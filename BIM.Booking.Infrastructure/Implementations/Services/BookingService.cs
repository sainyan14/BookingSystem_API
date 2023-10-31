using AutoMapper;
using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.Interfaces.Repositories;
using BIM.Booking.Application.Interfaces.Services;
using BIM.Booking.Application.Middleware;
using BIM.Booking.Domain.Models;
using BIM.Booking.Infrastructure.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Infrastructure.Implementations.Services
{
    public class BookingService :IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<BookingDto> GetBookingById(int id)
        {
            var booking = await _bookingRepository.Get(id);
            if (booking == null)
            {
                throw new NotFoundException($"No data found for Id - {id}");
            }
            else
            {
                BookingDto response = _mapper.Map<BookingDto>(booking);
                return response;
            }

        }

        public async Task AddBookingDto(AddBookingDto bookingDto)
        {
            var book = _mapper.Map<Bookings>(bookingDto);
            await _bookingRepository.Add(book);
        }

        public async Task UpdateBookingDto(UpdateBookingDto updatebookingDto)
        {
            var booking = _mapper.Map<Bookings>(updatebookingDto);
            var oldBooking = await _bookingRepository.Get(booking.BookingId);
            if (oldBooking == null)
            {
                throw new NotFoundException($"No data found to Update for Id - {booking.BookingId}");
            }
            else
            {
                oldBooking.HospitalId = booking.HospitalId;
                oldBooking.DoctorId = booking.DoctorId;
                oldBooking.PatientId = booking.PatientId;
                oldBooking.ServiceId = booking.ServiceId;
                oldBooking.PaymentId = booking.PaymentId;
                oldBooking.TicketNumber = booking.TicketNumber;
                oldBooking.CreateDate = booking.CreateDate;
                oldBooking.ModifyDate = booking.ModifyDate;
                oldBooking.IsActive = booking.IsActive;
                await _bookingRepository.Update(oldBooking);
            }

        }



        public async Task DeleteBookingDto(int id)
        {
            var booking = await _bookingRepository.Get(id);
            if (booking == null)
            {
                throw new NotFoundException($"No data found to Delete for Id - {id}");
            }
            else
            {
                await _bookingRepository.Delete(booking);
            }
        }

        public async Task<List<BookingDto>> GetAllBookings()
        {
            var booking = await _bookingRepository.GetAll();
            if (booking == null)
            {
                throw new NotFoundException($"No data found");
            }
            else
            {
                List<BookingDto> respond = _mapper.Map<List<BookingDto>>(booking);
                return respond;
            }
        }





    }
}
