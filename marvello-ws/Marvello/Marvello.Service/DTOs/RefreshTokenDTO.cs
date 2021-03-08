using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Service.DTOs
{
    public class RefreshTokenDTO
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public bool IsExpired { get; set; }
        public long UserId { get; set; }
        public DateTime ExpiredOn { get; set; }
        public DateTime? Revoked { get; set; }
    }
}
