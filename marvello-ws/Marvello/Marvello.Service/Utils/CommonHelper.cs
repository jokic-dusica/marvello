using AutoMapper.Configuration;
using Marvello.Data.Entities;
using Marvello.Data.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Marvello.Service.Utils
{
   public class CommonHelper
    {
        
        public static string GetDescription(object enumVal, Type tp = null)
        {
            if (tp == null) tp = enumVal.GetType();

            FieldInfo field = tp.GetField(enumVal.ToString());

            DescriptionAttribute attribute
                = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                    as DescriptionAttribute;

            return attribute == null ? enumVal.ToString() : attribute.Description;

        }

        public static RefreshToken CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    ExpiredOn = DateTime.UtcNow.AddDays(10),
                };
            }
        }
        public static string CreateJWTToken(User userFromDB, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var claims = new List<Claim>();
            var isAdminCheck = userFromDB.UserType == (int)UserTypeEnum.Administrator ? true : false;
            var roleClaim = isAdminCheck ? new Claim(ClaimTypes.Role, "Admin") : new Claim(ClaimTypes.Role, "Regular");
            claims.Add(roleClaim);

            claims.Add(new Claim("id", userFromDB.Id.ToString()));
            var secretKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWT:Secret").Value));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenOptions = new JwtSecurityToken(

                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials,
                claims: claims

                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return jwtToken;
        }

    }
}
