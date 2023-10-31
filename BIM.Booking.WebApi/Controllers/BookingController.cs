using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.Interfaces.Services;
using BIM.Booking.Application.Middleware;
using BIM.Booking.Domain.Models;
using BIM.Booking.Infrastructure.Implementations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BIM.Booking.Application.Middleware.HttpCodeandMessage;

namespace BIM.Booking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("get-booking/{id}")]
        public async Task<ActionResult> GetBookingById(int id)
        {
            try
            {
                var booking = await _bookingService.GetBookingById(id);
                return Ok(new RespondDto<BookingDto>
                {
                    Data = booking
                });
            }
            catch (NotFoundException e)
            {
                return Ok(new RespondDto<string>
                {
                    Code = Codes.NotFound,
                    Message = Messages.NotFound,
                    Data = e.Message
                });
            }
            catch (Exception e)
            {
                return Ok(new RespondDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBooking(AddBookingDto addBookingDto)
        {
            try
            {

                await _bookingService.AddBookingDto(addBookingDto);
                return Ok(new RespondDto<string>
                {
                    Code = Codes.OK,
                    Message = Messages.OK,
                    Data = "SuccessFully Created"
                });

            }
            catch (Exception e)
            {
                return Ok(new RespondDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            try
            {

                await _bookingService.UpdateBookingDto(updateBookingDto);
                return Ok(new RespondDto<string>
                {
                    Code = Codes.OK,
                    Message = Messages.OK,
                    Data = "SuccessFully Updated"
                });

            }
            catch (NotFoundException e)
            {
                return Ok(new RespondDto<string>
                {
                    Code = Codes.NotFound,
                    Message = Messages.NotFound,
                    Data = e.Message
                });
            }
            catch (Exception e)
            {
                return Ok(new RespondDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingDto(int id)
        {
            try
            {
                await _bookingService.DeleteBookingDto(id);
                return Ok(new RespondDto<string>
                {
                    Code = Codes.OK,
                    Message = Messages.OK,
                    Data = "SuccessFully Deleted"
                });
            }
            catch (NotFoundException e)
            {
                return Ok(new RespondDto<string>
                {
                    Code = Codes.NotFound,
                    Message = Messages.NotFound,
                    Data = e.Message
                });
            }
            catch (Exception e)
            {
                return Ok(new RespondDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooking()
        {
            try
            {
                var booking = await _bookingService.GetAllBookings();
                return Ok(new RespondDto<List<BookingDto>>
                {
                    Data = booking
                });
            }
            catch (NotFoundException e)
            {
                return Ok(new RespondDto<string>
                {
                    Code = Codes.NotFound,
                    Message = Messages.NotFound,
                    Data = e.Message
                });
            }
            catch (Exception e)
            {
                return Ok(new RespondDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }


    }
}
