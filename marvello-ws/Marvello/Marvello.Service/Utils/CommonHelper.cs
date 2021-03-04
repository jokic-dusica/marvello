using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
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

    }
}
