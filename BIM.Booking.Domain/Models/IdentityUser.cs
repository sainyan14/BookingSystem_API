﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIM.Booking.Domain.Models;

public partial class IdentityUser
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    public string UserName { get; set; }

    [Required]
    [StringLength(50)]
    public string UserType { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    [Required]
    [StringLength(100)]
    public string Hashcode { get; set; }

    [Required]
    public bool? IsActive { get; set; }

    [InverseProperty("IdentityUser")]
    public virtual ICollection<Admin> Admin { get; set; } = new List<Admin>();

    [InverseProperty("User")]
    public virtual ICollection<IdentityRefreshToken> IdentityRefreshToken { get; set; } = new List<IdentityRefreshToken>();

    [InverseProperty("User")]
    public virtual ICollection<Patients> Patients { get; set; } = new List<Patients>();
}