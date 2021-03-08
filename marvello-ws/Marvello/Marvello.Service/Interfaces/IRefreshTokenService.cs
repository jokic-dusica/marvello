using Marvello.Data.Entities;
using Marvello.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<RefreshTokenDTO> GetTokenByUser(long userId);
        Task<RefreshTokenDTO> GetTokenByToken(string cookieToken);
        Task<RefreshTokenDTO> SaveRefreshToken(RefreshTokenDTO refreshTokenDTO, bool isUpdate);
    }
}
