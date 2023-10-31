using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.Interfaces.Repositories;
using BIM.Booking.Application.Interfaces.Services;
using BIM.Booking.Application.Middleware;
using BIM.Booking.Domain.Models;
using BIM.Booking.Infrastructure.Implementations.Repositories;

namespace BIM.Booking.Infrastructure.Implementations.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public async Task<PatientDto> GetPatientById(int id)
        {
            var patient = await _patientRepository.Get(id);
            if (patient == null)
            {
                throw new NotFoundException($"No data found for Id - {id}");
            }
            else
            {
                PatientDto response = _mapper.Map<PatientDto>(patient);
                return response;
            }
        }

        //public async Task AddPatientDto(AddPatientDto addPatientDto)
        //{
        //    var patient = _mapper.Map<Patients>(addPatientDto);
        //    await _patientRepository.Add(patient);
        //}

        public async Task UpdatePatientDto(UpdatePatientDto updatePatientDto)
        {
            var patient = _mapper.Map<Patients>(updatePatientDto);
            var oldPatient = await _patientRepository.Get(patient.PatientId);



            if (oldPatient == null)
            {
                throw new NotFoundException($"No data found to Update for Id - {patient.PatientId}");
            }
            else
            {
                oldPatient.UserId = patient.UserId;
                oldPatient.Name = patient.Name;
                oldPatient.DateOfBirth = patient.DateOfBirth;
                oldPatient.Gender = patient.Gender;
                oldPatient.Phone = patient.Phone;
                oldPatient.Email = patient.Email;
                oldPatient.Address = patient.Address;
                oldPatient.IsActive = patient.IsActive;
                oldPatient.User = null;
                await _patientRepository.Update(oldPatient);
            }

        }


        public async Task DeletePatientDto(int id)
        {
            var patient = await _patientRepository.Get(id);
            if (patient == null)
            {
                throw new NotFoundException($"No data found to Delete for Id - {id}");
            }
            else
            {
                await _patientRepository.Delete(patient);
            }
        }

        public async Task<List<PatientDto>> GetAllPatients()
        {
            var patient = await _patientRepository.GetAll();
            if (patient == null)
            {
                throw new NotFoundException($"No data found");
            }
            else
            {
                List<PatientDto> respond = _mapper.Map<List<PatientDto>>(patient);
                return respond;
            }
        }

    }
}
