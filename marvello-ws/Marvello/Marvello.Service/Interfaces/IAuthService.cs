using Marvello.Service.DTOs;
using Marvello.Service.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseWrapper<AuthDTO>> SignIn(LoginDTO login);
        Task<ResponseWrapper<AuthDTO>> SignUp(RegisterUserDTO user);
        Task<ResponseWrapper<AuthDTO>> RefreshToken(string token);
    }
}
