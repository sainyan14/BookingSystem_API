using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.Interfaces.Services;
using BIM.Booking.Application.Middleware;
using BIM.Booking.Domain.Models;
using BIM.Booking.Infrastructure.Implementations.Services;
using Microsoft.AspNetCore.Mvc;
using static BIM.Booking.Application.Middleware.HttpCodeandMessage;

namespace BIM.Booking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("get-patient/{id}")]
        public async Task<ActionResult> GetPatientById(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientById(id);
                return Ok(new RespondDto<PatientDto>
                {
                    Data = patient
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


        //[HttpPost("add")]
        //public async Task<IActionResult> AddPatient(AddPatientDto addPatientDto)
        //{
        //    try
        //    {

        //        await _patientService.AddPatientDto(addPatientDto);
        //        return Ok(new RespondDto<string>
        //        {
        //            Code = Codes.OK,
        //            Message = Messages.OK,
        //            Data = "SuccessFully Created"
        //        });

        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new RespondDto<string>
        //        {
        //            Code = Codes.InternalServerError,
        //            Message = Messages.InternalServerError,
        //            Data = e.Message
        //        });
        //    }
        //}

        [HttpPost("update")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientDto updatePatientDto)
        {
            try
            {

                await _patientService.UpdatePatientDto(updatePatientDto);
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
        public async Task<IActionResult> DeletePatientDto(int id)
        {
            try
            {
                await _patientService.DeletePatientDto(id);
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
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patient = await _patientService.GetAllPatients();
                return Ok(new RespondDto<List<PatientDto>>
                {
                    Data = patient
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
