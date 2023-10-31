using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BIM.Booking.Application
{
    public static class Codes
    {
        public const int OK = 200;
        public const int BadRequest = 400;
        public const int NotFound = 404;
        public const int InternalServerError = 500;
        public const int Unauthorize = 401;
        public const int Forbidden = 403;
    }

    public static class Messages
    {
        public const string OK = "Ok";
        public const string BadRequest = "Bad Request";
        public const string NotFound = "No Record Found";
        public const string InternalServerError = "Internal Server Error";
        public const string Unauthorize = "Invalid or Expire Token";
        public const string Forbidden = "You are not Allowed to Access";
    }
}
