using BIM.Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Interfaces.Repositories
{
    public interface IHospitalRepository
    {
        Task Add(Hospital hospital );
        Task Update(Hospital hospital);
        Task Delete(Hospital hospital);
        Task<List<Hospital>> GetAll();
        Task<Hospital> Get(int id);
    }
}
