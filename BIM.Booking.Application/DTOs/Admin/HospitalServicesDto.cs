using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.DTOs.Admin
{
    public class HospitalServicesDto
    {
        public int HospitalServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

    }

    public class AddHospitalServicesDto
    {
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        [Required]
        public int HospitalId { get; set; }


    }

    public class UpdateHospitalServicesDto : AddHospitalServicesDto
    {
        [Required]
        public int HospitalServiceId { get; set; }

    }

}
