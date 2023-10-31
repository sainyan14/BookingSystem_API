using BIM.Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Repositories
{
    public interface IHospitalServicesRepository 
    {
        Task Add(HospitalServices services);
        Task Update(HospitalServices services);
        Task Delete(HospitalServices services);
        Task<List<HospitalServices>> GetAll();
        Task<HospitalServices> Get(int id);

    }
}
