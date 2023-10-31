using BIM.Booking.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Services
{
    public interface IDoctorService
    {
        Task<DoctorDto> GetDoctorById(int id);
        Task AddDoctorDto(AddDoctorDto doctorDto);
        Task UpdateDoctorDto(UpdateDoctorDto doctorDto);
        Task DeleteDoctorDto(int id);
        Task <List<DoctorDto>> GetAllDoctors();
        
    }
}
