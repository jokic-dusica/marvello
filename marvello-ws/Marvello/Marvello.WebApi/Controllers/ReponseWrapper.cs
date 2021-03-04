using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Marvello.WebApi.Controllers
{
    internal class ReponseWrapper<T> : ModelStateDictionary
    {
    }
}