using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Middleware
{
    public class HttpCodeandMessage
    {
        public static class Codes
        {
            public const int OK = 200;
            public const int BadRequest = 400;
            public const int NotFound = 404;
            public const int InternalServerError = 500;
        }

        public static class Messages
        {
            public const string OK = "Ok";
            public const string BadRequest = "Bad Request";
            public const string NotFound = "No Record Found";
            public const string InternalServerError = "Internal Server Error";
        }
    }
}
