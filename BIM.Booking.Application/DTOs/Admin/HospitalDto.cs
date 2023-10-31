using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.DTOs.Admin
{
    public class HospitalDto
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }


    }

    public class AddHospitalDto
    {
        [Required]
        public string HospitalName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        
        public string? Image { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }

    public class UpdateHospitalDto : AddHospitalDto
    {
        [Required]
        public int HospitalId { get; set; }
    }
}
