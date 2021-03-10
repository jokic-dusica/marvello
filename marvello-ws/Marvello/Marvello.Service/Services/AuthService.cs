using AutoMapper;
using Marvello.Data.Entities;
using Marvello.Data.Enums;
using Marvello.Repository.Interfaces;
using Marvello.Service.DTOs;
using Marvello.Service.Enums;
using Marvello.Service.Interfaces;
using Marvello.Service.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Marvello.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepostiory;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IRefreshTokenService _refreshTokenService;
        public AuthService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper, IRefreshTokenService refreshTokenService)
        {
            _userRepostiory = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<ResponseWrapper<AuthDTO>> RefreshToken(string token)
        {
            var refreshToken = await _refreshTokenService.GetTokenByToken(token);
           if(refreshToken != null)
            {
                var userFromDB =await  _userRepostiory.GetOne(refreshToken.UserId);
                await _refreshTokenService.SaveRefreshToken(refreshToken, true);
                var newRefreshToken = CommonHelper.CreateRefreshToken();
                newRefreshToken.UserId = userFromDB.Id;
                var newRefreshTokenDTO = _mapper.Map<RefreshTokenDTO>(newRefreshToken);
                newRefreshTokenDTO =  await _refreshTokenService.SaveRefreshToken(newRefreshTokenDTO, false);
                var jwtToken = CommonHelper.CreateJWTToken(userFromDB, _configuration);
                var isAdminCheck = userFromDB.UserType == (int)UserTypeEnum.Administrator ? true : false;
                var successLogin = new AuthDTO
                {
                    Token = jwtToken,
                    IsAdmin = isAdminCheck,
                    RefreshToken = newRefreshTokenDTO.Token,
                    RefreshTokenExpires = newRefreshTokenDTO.ExpiredOn

                };
                return new ResponseWrapper<AuthDTO>()
                {
                    ResponseData = successLogin,
                    IsSuccess = true
                };
            }

            return new ResponseWrapper<AuthDTO>()
            {
                IsSuccess = false
            };
        }

        public async Task<ResponseWrapper<AuthDTO>> SignIn(LoginDTO login)
        {
            var userFromDB = await  _userRepostiory.FirstOrDefault(user => user.Username == login.Username || user.Email == login.Username);
            if(userFromDB == null)
            {
                return new ResponseWrapper<AuthDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.IncorrectLoginData),
                    IsSuccess = false
                };
            }
            bool verified = CommonHelper.CheckPassword(login.Password, userFromDB.Password);
            if (!verified)
            {
                return new ResponseWrapper<AuthDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.IncorrectLoginData),
                    IsSuccess = false
                };
            }

          
            var isAdminCheck = userFromDB.UserType == (int)UserTypeEnum.Administrator ? true : false;

            var token = CommonHelper.CreateJWTToken(userFromDB, _configuration);
            var refreshToken =await  _refreshTokenService.GetTokenByUser(userFromDB.Id);
            if(refreshToken == null)
            {
                var newToken = CommonHelper.CreateRefreshToken();
                newToken.UserId = userFromDB.Id;
                var newTokenDTO = _mapper.Map<RefreshTokenDTO>(newToken);
                refreshToken =  await _refreshTokenService.SaveRefreshToken(newTokenDTO, false);
            }

            var successLogin = new AuthDTO
            {
                Token = token,
                IsAdmin = isAdminCheck,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpires = refreshToken.ExpiredOn

            };
            return new ResponseWrapper<AuthDTO>()
            {
                ResponseData = successLogin,
                IsSuccess = true
            };

        }

        public async Task<ResponseWrapper<AuthDTO>> SignUp(RegisterUserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            userEntity.CreatedOn = DateTime.UtcNow;
            userEntity.UserType = (int)UserTypeEnum.Regular;
            await _userRepostiory.Save(userEntity);
            var isAdminCheck = userEntity.UserType == (int)UserTypeEnum.Administrator ? true : false;
         
            var token = CommonHelper.CreateJWTToken(userEntity, _configuration);
            var successLogin = new AuthDTO
            {
                Token = token,
                IsAdmin = isAdminCheck
            };
            return new ResponseWrapper<AuthDTO>()
            {
                ResponseData = successLogin,
                IsSuccess = true
            };

        }
    }
}
