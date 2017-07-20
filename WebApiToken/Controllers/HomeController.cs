using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiToken.Controllers
{
    public class HomeController : ApiController
    {
        [Authorize]
        public string Get()
        {
            return "Hello World WebApi utilizando TOKEN!, você é um usuário autorizado.";
        }
    }
}
