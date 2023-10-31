using BIM.Booking.Application.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.DTOs
{
    public class RespondDto<T>
    {
        public int Code { get; set; } = HttpCodeandMessage.Codes.OK;
        public string Message { get; set; } = HttpCodeandMessage.Messages.OK;
        public T Data { get; set; } = default;
    }
}
