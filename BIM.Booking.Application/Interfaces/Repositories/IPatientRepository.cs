using BIM.Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        //Task Add(Patients patients);
        Task Update(Patients patients);
        Task Delete(Patients patients);
        Task<List<Patients>> GetAll();
        Task<Patients> Get(int id);
    }
}
