using AutoMapper;
using BIM.Booking.Application.DTOs;
using BIM.Booking.Application.DTOs.Admin;
using BIM.Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Mapping
{
    public class MappingProfile :Profile
    {

        public MappingProfile()
        {

            #region Hospital
            CreateMap<Hospital, HospitalDto>();
            CreateMap<AddHospitalDto, Hospital>().ReverseMap();
            CreateMap<UpdateHospitalDto, Hospital>().ReverseMap();
            #endregion
            #region Services

            CreateMap<HospitalServices, HospitalServicesDto>();
            CreateMap<AddHospitalServicesDto, HospitalServices>().ReverseMap();
            CreateMap<UpdateHospitalDto, HospitalServices>().ReverseMap();

            #endregion

            #region Doctors
            CreateMap<Doctors, DoctorDto>()
                .ForMember(d => d.ServiceName, s => s.MapFrom(s => s.Service.ServiceName))
                .ForMember(d => d.HospitalName, s => s.MapFrom(s => s.Hospital.HospitalName));

            CreateMap<AddDoctorDto, Doctors>().ReverseMap();

            CreateMap<UpdateDoctorDto, Doctors>().ReverseMap();
            #endregion


            #region Patients
            CreateMap<Patients, PatientDto>()
                .ForMember(d => d.UserId, s => s.MapFrom(s => s.User.UserId));

            //CreateMap<AddPatientDto, Patients>().ReverseMap();
            CreateMap<UpdatePatientDto, Patients>().ReverseMap();
            #endregion

            #region Appointment
            CreateMap<Appointments, AppointmentDto>()
                .ForMember(d => d.DoctorId, s => s.MapFrom(s => s.Doctor.DoctorId));
            CreateMap<UpdateAppointmentDto, Appointments>().ReverseMap();
            #endregion

            #region Booking
            CreateMap<Bookings, BookingDto>()
                .ForMember(d => d.HospitalId, s => s.MapFrom(s => s.Hospital.HospitalId))
                .ForMember(d => d.DoctorId, s => s.MapFrom(s => s.Doctor.DoctorId))
                .ForMember(d => d.PatientId, s => s.MapFrom(s => s.Patient.PatientId))
                .ForMember(d => d.ServiceId, s => s.MapFrom(s => s.Service.ServiceId))
                .ForMember(d => d.PaymentId, s => s.MapFrom(s => s.Payment.PaymentId));

            CreateMap<AddBookingDto, Bookings>().ReverseMap();
            CreateMap<UpdateBookingDto, Bookings>().ReverseMap();
            #endregion

        }
    }
}
