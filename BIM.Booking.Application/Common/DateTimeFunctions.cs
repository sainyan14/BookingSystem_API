using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Common
{
    public class DateTimeFunctions
    {
        public static DateTime CurrentMyanmarStandardTime()
        {
            DateTime MyanmarStd;
            MyanmarStd = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Myanmar Standard Time");
            return MyanmarStd;
        }

        public static string CurrentDateTimeToString()
        {
            string dt = DateTime.UtcNow.ToString("dd MMM yyyy HH:mm:ss tt");
            return dt;
        }

        public static string DatetoString(DateTime date)
        {
            string dt = date.ToString("dd MMM yyyy");
            return dt;
        }

        public static string getAbbreviatedName(int month)
        {
            DateTime date = new DateTime(2020, month, 1);

            return date.ToString("MMM");
        }
    }
}
