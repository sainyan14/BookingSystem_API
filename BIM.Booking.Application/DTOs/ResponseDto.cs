using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;



namespace BIM.Booking.Application.DTOs
{
    public class ResponseDto<T>
    {
        public int Code { get; set; } = Codes.OK;
        public string Message { get; set; } = Messages.OK;
        public T Data { get; set; } = default;
    }
}
