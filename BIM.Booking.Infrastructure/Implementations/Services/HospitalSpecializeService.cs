using AutoMapper;
using BIM.Booking.Application;
using BIM.Booking.Application.DTOs.Admin;
using BIM.Booking.Application.Interfaces.Repositories;
using BIM.Booking.Application.Interfaces.Services;
using BIM.Booking.Domain.Models;
using BIM.Booking.Infrastructure.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Infrastructure.Implementations.Services
{
    public class HospitalSpecializeService : IHospitalSpecializeService
    {
        public readonly IHospitalServicesRepository _hospitalserviceRepository = new HospitalServicesRepository();
        private readonly IMapper _mapper;

        public HospitalSpecializeService(IHospitalServicesRepository hospitalServicesRepository, IMapper mapper)
        {
            _hospitalserviceRepository = hospitalServicesRepository;
            _mapper = mapper;
        }
        
        //get by id
        public async Task<HospitalServicesDto> GetServicesById(int id)
        {
            var sev = await _hospitalserviceRepository.Get(id);
            if(sev == null)
            {
                throw new NotFoundException($"No data found for Id-{id}");

            }
            else
            {
                HospitalServicesDto response = _mapper.Map<HospitalServicesDto>(sev);
                return response;
            }
        }


        // listing /get all
        public async Task<List<HospitalServicesDto>> GetHospitalServiceList()
        {
            var hop = await _hospitalserviceRepository.GetAll();
            if (hop == null)
            {
                throw new NotFoundException($"No data found for HospitalService list ");
            }
            else
            {
                List<HospitalServicesDto> response = _mapper.Map<List<HospitalServicesDto>>(hop);
                return response;
            }
        }


        public async Task AddServices(AddHospitalServicesDto serviceDto)
        {
            var service = _mapper.Map<HospitalServices>(serviceDto);
            await _hospitalserviceRepository.Add(service);
        }

        public async Task UpdateServices(UpdateHospitalServicesDto serviceDto)
        {
            var service = _mapper.Map<HospitalServices>(serviceDto);

            var oldservice = await _hospitalserviceRepository.Get(service.HospitalServiceId);
            if (oldservice == null)
            {
                throw new NotFoundException($"No data found to update for HospitalServiceId - {service.HospitalServiceId}");
            }
            else
            {
                oldservice.ServiceName = service.ServiceName;
                oldservice.Description = service.Description;
                oldservice.IsActive = service.IsActive;
                oldservice.HospitalId = service.HospitalId;

                await _hospitalserviceRepository.Update(oldservice);
            }
        }


        // Delete

        public async Task DeleteServices(int id)
        {
            var service = await _hospitalserviceRepository.Get(id);
            if (service == null)
            {
                throw new NotFoundException($"No data found to Delete for Id - {id}");
            }
            else
            {
                await _hospitalserviceRepository.Delete(service);
            }
        }
    }
}
