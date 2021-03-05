using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Service.DTOs
{
    public class AuthDTO
    {
        public string Token { get; set; }
        public DateTime RefreshTokenExpires { get; set; }
        public bool IsAdmin { get; set; }
    }
}
