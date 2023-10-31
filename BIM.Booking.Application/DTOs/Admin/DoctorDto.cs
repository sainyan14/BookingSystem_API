using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.DTOs
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }
        public string ServiceName { get; set; }
        public string HospitalName { get; set; }
        public bool IsActive { get; set; }
    }

    public class AddDoctorDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int HospitalId { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }

    public class UpdateDoctorDto : AddDoctorDto 
    {
        [Required]
        public int DoctorId { get; set; }

    }
}
