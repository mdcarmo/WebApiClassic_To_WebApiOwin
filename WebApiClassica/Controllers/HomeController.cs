using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiClassica.Controllers
{
    public class HomeController : ApiController
    {
        public string Get()
        {
            return "Hello World WEB API Clássica";
        }
    }
}
