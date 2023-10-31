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
    public class AppointmentRepository : IAppointmentRepository
    {
        public async Task Delete(Appointments appointments)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Appointments.Remove(appointments);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }

        public async Task<Appointments> Get(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.Appointments.Where(x => x.AppointmentId == id).Include(x => x.Doctor).FirstOrDefaultAsync();
            }
        }

        public async Task<List<Appointments>> GetAll()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.Appointments.Include(x => x.Doctor).ToListAsync();
            }
        }

        public async Task Update(Appointments appointments)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Appointments.Update(appointments);
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
