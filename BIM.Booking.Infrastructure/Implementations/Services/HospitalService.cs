using AutoMapper;
using BIM.Booking.Application.DTOs.Admin;
using BIM.Booking.Application.Interfaces.Repositories;
using BIM.Booking.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIM.Booking.Application.Middleware;
using BIM.Booking.Application;
using BIM.Booking.Domain.Models;
using BIM.Booking.Infrastructure.Implementations.Repositories;

namespace BIM.Booking.Infrastructure.Implementations.Services
{
    public class HospitalService : IHospitalService
    {
        public readonly IHospitalRepository _hospitalRepository = new HospitalRepository();
        private readonly IMapper _mapper;

        public HospitalService(IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        public async Task<HospitalDto> GetHospitalById(int id)
        {
            var hop = await _hospitalRepository.Get(id);
            if (hop == null)
            {
                throw new Application.NotFoundException($"No data found for Hospital Id - {id}");
            }
            else
            {
                HospitalDto response = _mapper.Map<HospitalDto>(hop);
                return response;
            }
        }
         //get all 

        public async Task<List<HospitalDto>> GetHospitalList()
        {
            var hop = await _hospitalRepository.GetAll();
            if (hop == null)
            {
                throw new Application.Middleware.NotFoundException($"No data found for Hospital list ");
            }
            else
            {
               List< HospitalDto> response = _mapper.Map<List<HospitalDto>>(hop);
                return response;
            }
        }

        public async Task AddHospital(AddHospitalDto hospitalDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalDto);
            await _hospitalRepository.Add(hospital);
        }

        public async Task UpdateHospital(UpdateHospitalDto hospitalDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalDto);

            var oldHospital = await _hospitalRepository.Get(hospital.HospitalId);
            if (oldHospital == null)
            {
                throw new Application.Middleware.NotFoundException($"No data found to update for Id - {hospital.HospitalId}");
            }
            else
            {
                oldHospital.HospitalName = hospital.HospitalName;
                oldHospital.Address = hospital.Address;
                oldHospital.Email = hospital.Email;
                oldHospital.Phone = hospital.Phone;
                oldHospital.Image = hospital.Image;
                oldHospital.IsActive = hospital.IsActive;
            
                await _hospitalRepository.Update(oldHospital);
            }
        }


        public async Task DeleteHospital(int id)
        {
            var hospital = await _hospitalRepository.Get(id);
            if (hospital == null)
            {
                throw new Application.Middleware.NotFoundException($"No data found to Delete for Id - {id}");
            }
            else
            {
                await _hospitalRepository.Delete(hospital);
            }
        }



      
    }
}
