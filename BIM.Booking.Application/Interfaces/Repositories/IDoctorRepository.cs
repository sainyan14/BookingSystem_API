using BIM.Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Repositories
{
    public interface IDoctorRepository
    {
        Task Add(Doctors doctors);
        Task Update(Doctors doctors);
        Task Delete(Doctors doctors);
        Task<List<Doctors>> GetAll();
        //Task<List<Doctors>> GetMany();
        Task<Doctors> Get(int id);
    }
}
