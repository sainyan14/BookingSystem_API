using BIM.Booking.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Services
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientById(int id);
        //Task AddPatientDto(AddPatientDto addPatientDto);
        Task UpdatePatientDto(UpdatePatientDto updatePatientDto);
        Task DeletePatientDto(int id);
        Task<List<PatientDto>> GetAllPatients();
    }
}
