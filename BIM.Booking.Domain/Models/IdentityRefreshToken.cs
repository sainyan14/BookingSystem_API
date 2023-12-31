﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIM.Booking.Domain.Models;

public partial class IdentityRefreshToken
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string Token { get; set; }

    [Required]
    [StringLength(50)]
    public string RefreshToken { get; set; }

    [Required]
    public bool? IsActive { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("IdentityRefreshToken")]
    public virtual IdentityUser User { get; set; }
}