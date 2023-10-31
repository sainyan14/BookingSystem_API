using BIM.Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        //Task Add(Appointments appointments);
        Task Update(Appointments appointments);
        Task Delete(Appointments appointments);
        Task<List<Appointments>> GetAll();
        Task<Appointments> Get(int id);
    }
}
