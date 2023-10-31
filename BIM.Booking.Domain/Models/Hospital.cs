﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIM.Booking.Domain.Models;

public partial class Hospital
{
    [Key]
    public int HospitalId { get; set; }
    [Required]
    [StringLength(50)]
    public string HospitalName { get; set; }

    [Required]
    [StringLength(1000)]
    public string Address { get; set; }

    [Required]
    [StringLength(50)]
    public string Email { get; set; }

    [Required]
    [StringLength(20)]
    public string Phone { get; set; }

  
    [StringLength(100)]
    public string Image { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [InverseProperty("Hospital")]
    public virtual ICollection<HospitalServices> HospitalServices { get; set; } = new List<HospitalServices>();
   
}