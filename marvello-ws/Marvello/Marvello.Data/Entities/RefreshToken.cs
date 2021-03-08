using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Data.Entities
{
    public class RefreshToken
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredOn { get; set; }
        public bool IsExpired => ExpiredOn > DateTime.Now && Revoked == null;
        public DateTime? Revoked { get; set; }
        public long UserId { get; set; }
        public virtual User User{get;set;}
    }
}
