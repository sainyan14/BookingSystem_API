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
    public class BookingRepository : IBookingRepository
    {
        public async Task Add(Bookings booking)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Bookings.Add(booking);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }

        public async Task Delete(Bookings booking)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Bookings.Remove(booking);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                await db.Database.CloseConnectionAsync();
            }
        }

        public async Task<Bookings> Get(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.Bookings.Where(x => x.BookingId == id)
                    .Include(x => x.Hospital).Include(x => x.Doctor)
                    .Include(x => x.Patient).Include(x => x.Service)
                    .Include(x => x.Payment).FirstOrDefaultAsync();
            }
        }
        public async Task<List<Bookings>> GetAll()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return await db.Bookings
                    .Include(x => x.Hospital).Include(x => x.Doctor)
                    .Include(x => x.Patient).Include(x => x.Service)
                    .Include(x => x.Payment).ToListAsync();
            }
        }

        public async Task Update(Bookings booking)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    db.Bookings.Update(booking);
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
