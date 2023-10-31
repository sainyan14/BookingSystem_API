using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.DTOs
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        //public static implicit operator PatientDto(List<PatientDto> v)
        //{
        //    throw new NotImplementedException();
        //}
    }

    //public class AddPatientDto
    //{
    //    [Required]
    //    public int UserId { get; set; }
    //    [Required]
    //    public string Name { get; set; }
    //    [Required]
    //    public string DateOfBirth { get; set; }
    //    [Required]
    //    public string Gender { get; set; }
    //    [Required]
    //    public string Phone { get; set; }
    //    [Required]
    //    public string Email { get; set; }
    //    [Required]
    //    public string Address { get; set; }
    //}

    public class UpdatePatientDto 
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
