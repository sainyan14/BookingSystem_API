using AutoMapper;
using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.Interfaces.Repositories;
using BIM.Booking.Application.Interfaces.Services;
using BIM.Booking.Application.Middleware;
using BIM.Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Infrastructure.Implementations.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doc = await _doctorRepository.Get(id);
            if (doc == null)
            {
                throw new NotFoundException($"No data found for Id - {id}");
            }
            else
            {
                DoctorDto response = _mapper.Map<DoctorDto>(doc);
                //DoctorDto response = new DoctorDto
                //{
                //    DoctorId = doc.DoctorId,
                //    Name = doc.Name,
                //    Specialization = doc.Specialization,
                //    ServiceName = doc.Service.ServiceName,
                //    HospitalName = doc.Hospital.HospitalName
                //};
                return response;
            }

        }

        public async Task AddDoctorDto(AddDoctorDto doctorDto)
        {
            var doc = _mapper.Map<Doctors>(doctorDto);
            await _doctorRepository.Add(doc);
        }

        public async Task UpdateDoctorDto(UpdateDoctorDto updateDoctorDto)
        {
            var doc = _mapper.Map<Doctors>(updateDoctorDto);
            var oldDoc = await _doctorRepository.Get(doc.DoctorId);
            if (oldDoc == null)
            {
                throw new NotFoundException($"No data found to Update for Id - {doc.DoctorId}");
            }
            else
            {
                oldDoc.Name = doc.Name;
                oldDoc.Qualification = doc.Qualification;
                oldDoc.ServiceId = doc.ServiceId;
                oldDoc.HospitalId = doc.HospitalId;
                oldDoc.Service = null;
                oldDoc.Hospital = null;
                oldDoc.IsActive = doc.IsActive;
                await _doctorRepository.Update(oldDoc);
            }

        }

        public async Task DeleteDoctorDto(int id)
        {

            var doc = await _doctorRepository.Get(id);
            if (doc == null)
            {
                throw new NotFoundException($"No data found to Delete for Id - {id}");
            }
            else
            {
                await _doctorRepository.Delete(doc);
            }
        }

        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            var doc = await _doctorRepository.GetAll();
            if (doc == null)
            {
                throw new NotFoundException($"No data found");
            }
            else
            {
                List<DoctorDto> respond = _mapper.Map<List<DoctorDto>>(doc);
                return respond;
            }
        }


    }
}
