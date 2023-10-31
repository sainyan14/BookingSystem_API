using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.DTOs.Admin;
using BIM.Booking.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BIM.Booking.Application;
using BIM.Booking.Infrastructure;
using SendGrid.Helpers.Errors.Model;
using Serilog;


namespace BIM.Booking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {

        public readonly IHospitalService _hospitalService;

        public HospitalController (IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

   //     [Authorize(Roles = "Admin,Superadmin")]
        [HttpGet("get/{id}")]

        public async Task<IActionResult> GetHospitalById(int id)
        {
            try
            {
             //   Log.Information("Start Getting Hospital ById");
                var hospital = await _hospitalService.GetHospitalById(id);
                return Ok(new ResponseDto<HospitalDto>
                {
                    Data = hospital
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
             //   Log.Information("Start Getting All Hospitals");
                var hospitals = await _hospitalService.GetHospitalList(); // Modify this method in your service to retrieve all hospitals.
                return Ok(new ResponseDto<List<HospitalDto>> // Assuming you want to return a list of HospitalDto.
                {
                    Data = hospitals
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
        public async Task<IActionResult> AddHospital(AddHospitalDto hospitalDto)
        {
            try
            {
                await _hospitalService.AddHospital(hospitalDto);
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
        public async Task<IActionResult> UpdateHospital(UpdateHospitalDto hospitalDto)
        {
            try
            {
                await _hospitalService.UpdateHospital(hospitalDto);
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
                await _hospitalService.DeleteHospital(id);
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
