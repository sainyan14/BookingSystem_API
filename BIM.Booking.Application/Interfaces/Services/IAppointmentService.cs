using BIM.Booking.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> GetAppointmentbyId(int id);
        //Task AddDoctorDto(AddDoctorDto doctorDto);
        Task UpdateAppointmentDto(UpdateAppointmentDto updateAppointmentDto);
        Task DeleteAppointmentDto(int id);
        //Task <List<DoctorDto>> GetAllDoctors();
        Task<List<AppointmentDto>> GetAllAppoinments();
    }
}
