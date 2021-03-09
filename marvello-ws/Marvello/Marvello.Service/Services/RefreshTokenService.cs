using AutoMapper;
using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using Marvello.Service.DTOs;
using Marvello.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Services
{
    public class RefreshTokenService : IRefreshTokenService
        
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMapper _mapper;
        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IMapper mapper)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
        }

        public async Task<RefreshTokenDTO> GetTokenByToken(string cookieToken)
        {
            var tokenResultList = await _refreshTokenRepository.GetWhere(token => token.Token == cookieToken);
            var tokenResult = tokenResultList.Where(t => t.IsExpired == false).FirstOrDefault();
            var tokenResultDTO = _mapper.Map<RefreshTokenDTO>(tokenResult);
            return tokenResultDTO;
        }

        public async Task<RefreshTokenDTO> GetTokenByUser(long userId)
        {
            var tokenList  = await _refreshTokenRepository.GetWhere(token => token.UserId == userId);
            var token = tokenList.Where(t => t.IsExpired == false).FirstOrDefault();
            var tokenDTO = _mapper.Map<RefreshTokenDTO>(token);
            return tokenDTO;
        }

        public async Task<RefreshTokenDTO> SaveRefreshToken(RefreshTokenDTO refreshTokenDTO, bool isUpdate = false)
        {
            var refreshToken= _mapper.Map<RefreshToken>(refreshTokenDTO);
            if(isUpdate == true)
            {
                refreshToken.Revoked = DateTime.Now;
                await _refreshTokenRepository.Update(refreshToken);
                refreshTokenDTO = _mapper.Map<RefreshTokenDTO>(refreshToken);
                return refreshTokenDTO;
            }
            await _refreshTokenRepository.Save(refreshToken);
            refreshTokenDTO = _mapper.Map<RefreshTokenDTO>(refreshToken);
            return refreshTokenDTO;
        }
    }
}
