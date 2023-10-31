using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.DTOs
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string AppointmentStatus { get; set; }
        public int PeopleLimit { get; set; }
        public int DoctorId { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateAppointmentDto
    {
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public TimeSpan AppointmentTime { get; set; }
        [Required]
        public string AppointmentStatus { get; set; }
        [Required]
        public int PeopleLimit { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
