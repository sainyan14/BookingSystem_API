using AutoMapper;
using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.Interfaces.Repositories;
using BIM.Booking.Application.Interfaces.Services;
using BIM.Booking.Application.Middleware;
using BIM.Booking.Domain.Models;
using BIM.Booking.Infrastructure.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Infrastructure.Implementations.Services
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> GetAppointmentbyId(int id)
        {
            var appointment = await _repository.Get(id);
            if (appointment == null)
            {
                throw new NotFoundException($"No data found for Id - {id}");
            }
            else
            {
                AppointmentDto response = _mapper.Map<AppointmentDto>(appointment);
                return response;
            }
        }


        public async Task UpdateAppointmentDto(UpdateAppointmentDto updateAppointmentDto)
        {
            var appointment = _mapper.Map<Appointments>(updateAppointmentDto);
            var oldappointment = await _repository.Get(appointment.AppointmentId);



            if (oldappointment == null)
            {
                throw new NotFoundException($"No data found to Update for Id - {appointment.AppointmentId}");
            }
            else
            {
                oldappointment.AppointmentDate = appointment.AppointmentDate;
                oldappointment.AppointmentTime = appointment.AppointmentTime;
                oldappointment.AppointmentStatus = appointment.AppointmentStatus;
                oldappointment.PeopleLimit = appointment.PeopleLimit;
                oldappointment.DoctorId = appointment.DoctorId;
                oldappointment.IsActive = appointment.IsActive;
                await _repository.Update(oldappointment);
            }

        }

        public async Task<List<AppointmentDto>> GetAllAppoinments()
        {
            var appointments = await _repository.GetAll();
            if (appointments == null)
            {
                throw new NotFoundException($"No data found");
            }
            else
            {
                List<AppointmentDto> respond = _mapper.Map<List<AppointmentDto>>(appointments);
                return respond;
            }
        }
        




        public async Task DeleteAppointmentDto(int id)
        {
            var appointment = await _repository.Get(id);
            if (appointment == null)
            {
                throw new NotFoundException($"No data found to Delete for Id - {id}");
            }
            else
            {
                await _repository.Delete(appointment);
            }
        }




    }
}
