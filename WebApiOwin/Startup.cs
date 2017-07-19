using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

//[assembly: OwinStartup(typeof(WebApiOwin.Startup))]

namespace WebApiOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //configuração WebApi
            var config = new HttpConfiguration();

            //configurando rotas
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            // ativando configuração WebApi
            app.UseWebApi(config);
        }
    }
}
