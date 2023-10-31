using BIM.Booking.Application.DTOs.Admin;
using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BIM.Booking.Application;
using SendGrid.Helpers.Errors.Model;
using Serilog;

namespace BIM.Booking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalServicesController : ControllerBase
    {

        public readonly IHospitalSpecializeService _hospitalService;

        public HospitalServicesController(IHospitalSpecializeService servicesService)
        {
            _hospitalService = servicesService;
        }

        [HttpGet("get/{id}")]

        public async Task<IActionResult> GetServicesById(int id)
        {
            try
            {
                var services = await _hospitalService.GetServicesById(id);
                return Ok(new ResponseDto<HospitalServicesDto>
                {
                    Data = services
                });
            }
            catch (NotFoundException e)
            {
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.NotFound,
                    Message = Messages.NotFound,
                    Data = e.Message
                });
            }
            catch (Exception e)
            {
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllHospitals()
        {
            try
            {
            //    Log.Information("Start Getting All Hospital Services");
                var hospitalServices = await _hospitalService.GetHospitalServiceList();
                return Ok(new ResponseDto<List<HospitalServicesDto>> 
                {
                    Data = hospitalServices
                });
            }
            catch (Exception e)
            {
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }



        [HttpPost("add")]
        public async Task<IActionResult> AddServices(AddHospitalServicesDto servicesDto)
        {
            try
            {
                await _hospitalService.AddServices(servicesDto);
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.OK,
                    Message = Messages.OK,
                    Data = "Successfully Created"
                });
            }
            catch (Exception e)
            {
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateServices(UpdateHospitalServicesDto servicesDto)
        {
            try
            {
                await _hospitalService.UpdateServices(servicesDto);
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.OK,
                    Message = Messages.OK,
                    Data = "Successfully Updated"
                });
            }
            catch (NotFoundException e)
            {
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.NotFound,
                    Message = Messages.NotFound,
                    Data = e.Message
                });
            }
            catch (Exception e)
            {
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _hospitalService.DeleteServices(id);
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.OK,
                    Message = Messages.OK,
                    Data = "Successfully Deleted"
                });
            }
            catch (NotFoundException e)
            {
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.NotFound,
                    Message = Messages.NotFound,
                    Data = e.Message
                });
            }
            catch (Exception e)
            {
                return Ok(new ResponseDto<string>
                {
                    Code = Codes.InternalServerError,
                    Message = Messages.InternalServerError,
                    Data = e.Message
                });
            }
        }









    }
}
