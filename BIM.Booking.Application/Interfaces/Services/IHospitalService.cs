using BIM.Booking.Application.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Services
{
    public interface IHospitalService
    {
        Task<HospitalDto> GetHospitalById(int id);
        Task<List<HospitalDto>> GetHospitalList();
        Task AddHospital(AddHospitalDto hospitalDto);
        Task UpdateHospital(UpdateHospitalDto hospitalDto);
        Task DeleteHospital(int id);
    }
}
