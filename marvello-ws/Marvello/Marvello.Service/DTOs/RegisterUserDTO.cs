using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Service.DTOs
{
    public class RegisterUserDTO : UserDTO
    {
        public string Password { get; set; }
    }
}
