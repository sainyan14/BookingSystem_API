using BIM.Booking.Application.Interfaces.Services;
using BIM.Booking.Domain.DBContext;
using BIM.Booking.Infrastructure.Implementations.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void RegisterBusinessServices(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            ApplicationDBContext.SetConnectionString(configuration.GetConnectionString("ApplicationDBContext"));

            services.AddTransient<IHospitalService, HospitalService>();
            services.AddTransient<IHospitalSpecializeService, HospitalSpecializeService>();
        }
    }
}
