using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelPet.Models
{
    public class AuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Nome => _accessor.HttpContext.Session.GetString("username");
        public string Cpf => _accessor.HttpContext.Session.GetString("Cpf");
        public string Cnpj => _accessor.HttpContext.Session.GetString("Cnpj");


    }
}
