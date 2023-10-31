using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.DTOs
{
    public class BookingDto
    {
        public int BookingId { get; set; }

        public int HospitalId { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public int ServiceId { get; set; }

        public int PaymentId { get; set; }
        public string TicketNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsActive { get; set; }

    }

    public class AddBookingDto
    {
        [Required]
        public int HospitalId { get; set; }
        [Required]

        public int DoctorId { get; set; }
        [Required]

        public int PatientId { get; set; }
        [Required]

        public int ServiceId { get; set; }
        [Required]

        public int PaymentId { get; set; }
        [Required]
        public string TicketNumber { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }

    public class UpdateBookingDto: AddBookingDto
    {
        [Required]
        public int BookingId { get; set; }
    }





}
