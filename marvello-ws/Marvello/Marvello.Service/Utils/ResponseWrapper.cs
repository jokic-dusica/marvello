using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Service.Utils
{
    public class ResponseWrapper<T> where T : class
    {
        public T ResponseData { get; set; } 
        public string ErrorMessage { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } 
    }
}
