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
    public class PatientRepository : IPatientRepository
    {
        //public async Task Add(Patients patients)
        //{
        //    using (ApplicationDBContext db = new ApplicationDBContext())
        //    {
        //        try
        //        {
        //            db.Patients.Add(patients);
        //            await db.SaveChangesAsync();
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        await db.Database.CloseConnectionAsync();
        //    }
        //}

        public async Task Delete(Patients patients)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Patients.Remove(patients);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }

        public async Task<Patients> Get(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.Patients.Where(x => x.PatientId == id).Include(x => x.User).FirstOrDefaultAsync();
            }
        }

        public async Task<List<Patients>> GetAll()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.Patients.Include(x => x.User).ToListAsync();
            }
        }

        public async Task Update(Patients patients)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Patients.Update(patients);
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
