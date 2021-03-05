﻿using AutoMapper;
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
        public AuthService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepostiory = userRepository;
            _configuration = configuration;
            _mapper = mapper;
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

            bool verified = BCrypt.Net.BCrypt.Verify(login.Password, userFromDB.Password);
            if(!verified)
            {
                return new ResponseWrapper<AuthDTO>()
                {
                    ErrorMessage = CommonHelper.GetDescription(ExceptionEnum.IncorrectLoginData),
                    IsSuccess = false
                };
            }

            var claims = new List<Claim>();
            var isAdminCheck = userFromDB.UserType == (int)UserTypeEnum.Administrator ? true : false;
            var roleClaim = isAdminCheck ? new Claim(ClaimTypes.Role, "Admin") : new Claim(ClaimTypes.Role, "Regular");
            claims.Add(roleClaim);

            claims.Add(new Claim("id", userFromDB.Id.ToString()));
            var secretKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenOptions = new JwtSecurityToken(
                
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials,
                claims: claims

                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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

        public async Task<ResponseWrapper<AuthDTO>> SignUp(RegisterUserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            userEntity.CreatedOn = DateTime.UtcNow;
            await _userRepostiory.Save(userEntity);

            var claims = new List<Claim>();
            var isAdminCheck = userEntity.UserType == (int)UserTypeEnum.Administrator ? true : false;
            var roleClaim = isAdminCheck ? new Claim(ClaimTypes.Role, "Admin") : new Claim(ClaimTypes.Role, "Regular");
            claims.Add(roleClaim);

            claims.Add(new Claim("id", userEntity.Id.ToString()));
            var secretKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenOptions = new JwtSecurityToken(

                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials,
                claims: claims

                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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