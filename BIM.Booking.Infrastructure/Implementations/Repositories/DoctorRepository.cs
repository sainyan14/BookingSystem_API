using BIM.Booking.Application.Interfaces.Repositories;
using BIM.Booking.Domain.DBContext;
using BIM.Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Infrastructure.Implementations.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        public async Task Add(Doctors doctors)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Doctors.Add(doctors);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }

        public async Task Delete(Doctors doctors)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Doctors.Remove(doctors);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }

        public async Task<Doctors> Get(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext ())
            {
                return await db.Doctors.Where(x => x.DoctorId == id).Include(x => x.Service).Include(x=>x.Hospital).FirstOrDefaultAsync();
            }
        }

        public async Task<List<Doctors>> GetAll()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.Doctors.Include(x => x.Hospital).Include(x => x.Service).ToListAsync();
            }
        }

        public async Task Update(Doctors doctors)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Doctors.Update(doctors);
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
