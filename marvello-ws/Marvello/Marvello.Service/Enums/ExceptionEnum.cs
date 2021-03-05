using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Marvello.Service.Enums
{
    public enum ExceptionEnum
    {
        [Description ("Something went wrong, please try again!") ]
        ServerError = 0,

        [Description("Searched entity is not found!")]
        NotFoundError = 1,

        [Description("Request from client is inncorrect!")]
        BadRequestError = 2,

        [Description("Incorrect Username or Password")]
        IncorrectLoginData = 3

    }
}
