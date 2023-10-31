using BIM.Booking.Application.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Middleware
{
    public class StatusCodeMiddleware
    {

        private readonly RequestDelegate _next;

        public StatusCodeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            switch (context.Response.StatusCode)
            {
                case 401:
                    Handle401(context); break;
                case 403:
                    Handle403(context); break;
                case 500:
                    Handle500(context); break;

            }
        }

        private async Task Handle403(HttpContext context)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsJsonAsync(new ResponseDto<string>
            {
                Code = Codes.Forbidden,
                Message = Messages.Forbidden,
                Data = null
            });
        }
        private async Task Handle401(HttpContext context)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsJsonAsync(new ResponseDto<string>
            {
                Code = Codes.Unauthorize,
                Message = Messages.Unauthorize,
                Data = null
            });
        }

        private async Task Handle500(HttpContext context)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsJsonAsync(new ResponseDto<string>
            {
                Code = Codes.InternalServerError,
                Message = Messages.InternalServerError,
                Data = null
            });
        }
    }
}
