using BIM.Booking.Application.Interfaces.Repositories;
using BIM.Booking.Domain.DBContext;
using BIM.Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Infrastructure.Implementations.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        public async Task Add(Hospital hospital)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Hospital.Add(hospital);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }

  

        public async Task<Hospital> Get(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.Hospital.Where(x => x.HospitalId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<List<Hospital>> GetAll()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.Hospital.ToListAsync();
            }
        }

        public async Task Update(Hospital hospital)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Hospital.Update(hospital);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }


        public async Task Delete(Hospital hospital)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Hospital.Remove(hospital);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }

    }
}
