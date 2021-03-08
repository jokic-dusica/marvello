using Marvello.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
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

    }
}
