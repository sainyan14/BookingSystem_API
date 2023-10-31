using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.Interfaces.Services;
using BIM.Booking.Application.Middleware;
using BIM.Booking.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static BIM.Booking.Application.Middleware.HttpCodeandMessage;

namespace BIM.Booking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        //[Authorize]
        [HttpGet("get-doctor/{id}")]
        public async Task<ActionResult> GetDoctorById(int id)
        {
            try
            {
                var doc = await _doctorService.GetDoctorById(id);
                return Ok(new RespondDto<DoctorDto>
                {
                    Data = doc
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
        public async Task<IActionResult> AddDoctor(AddDoctorDto addDoctorDto)
        {
            try
            {

               await _doctorService.AddDoctorDto(addDoctorDto);
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
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto updateDoctorDto)
        {
            try
            {

                await _doctorService.UpdateDoctorDto(updateDoctorDto);
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
        public async Task<IActionResult> DeleteDoctorDto(int id)
        {
            try
            {
                await _doctorService.DeleteDoctorDto(id);
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
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doc = await _doctorService.GetAllDoctors();
                return Ok(new RespondDto<List<DoctorDto>>
                {
                    Data = doc
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
