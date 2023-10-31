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
    public class HospitalServicesRepository : IHospitalServicesRepository
    {
        public async Task Add(HospitalServices services)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.HospitalServices.Add(services);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }

        public async Task<HospitalServices> Get(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.HospitalServices.Where(x => x.HospitalServiceId == id).Include (x => x.Hospital).FirstOrDefaultAsync();
            }
        }

        public async Task<List<HospitalServices>> GetAll()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.HospitalServices.Include(x=>x.Hospital).ToListAsync();
            }
        }

        public async Task Update(HospitalServices services)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.HospitalServices.Update(services);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }


        public async Task Delete(HospitalServices services)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.HospitalServices.Remove(services);
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
