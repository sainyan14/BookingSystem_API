using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Application.DTOs.Authentication
{
    public class IdentityUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string Hashcode { get; set; }
    }

    public class IdentityRefreshTokenDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

    }


}
