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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }


        [HttpGet("get-appointment/{id}")]
        public async Task<ActionResult> GetAppointmentById(int id)
        {
            try
            {
                var appointment = await _appointmentService.GetAppointmentbyId(id);
                return Ok(new RespondDto<AppointmentDto>
                {
                    Data = appointment
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


        [HttpPost("update")]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentDto updateAppointmentDto)
        {
            try
            {

                await _appointmentService.UpdateAppointmentDto(updateAppointmentDto);
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
        public async Task<IActionResult> DeleteAppointmentDto(int id)
        {
            try
            {
                await _appointmentService.DeleteAppointmentDto(id);
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
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                var appoinment = await _appointmentService.GetAllAppoinments();
                return Ok(new RespondDto<List<AppointmentDto>>
                {
                    Data = appoinment
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
