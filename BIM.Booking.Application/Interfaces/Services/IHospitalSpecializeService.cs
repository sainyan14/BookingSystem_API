using BIM.Booking.Application.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Services
{
    public interface IHospitalSpecializeService
    {
        Task<HospitalServicesDto> GetServicesById(int id);
        Task<List<HospitalServicesDto>> GetHospitalServiceList();
        Task AddServices(AddHospitalServicesDto serviceDto);
        Task UpdateServices(UpdateHospitalServicesDto serviceDto);
        Task DeleteServices(int id);
    }
}
