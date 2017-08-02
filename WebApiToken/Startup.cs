using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Cors;

namespace WebApiToken
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
                        
            ConfigureAccessToken(app);

            //habilitando o CORS
            app.UseCors(CorsOptions.AllowAll);
           
            // ativando configuração WebApi
            app.UseWebApi(config);
        }

        private void ConfigureAccessToken(IAppBuilder app)
        {
            var optionsConfigurationToken = new OAuthAuthorizationServerOptions()
            {
                //Permitindo acesso ao endereço de fornecimento do token de acesso sem 
                //precisar de HTTPS (AllowInsecureHttp). 
                //Em produção o valor deve ser false.

                AllowInsecureHttp = true,

                //Configurando o endereço do fornecimento do token de acesso (TokenEndpointPath).
                TokenEndpointPath = new PathString("/token"),

                //Configurando por quanto tempo um token de acesso já forncedido valerá (AccessTokenExpireTimeSpan).
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1),

                //Como verificar usuário e senha para fornecer tokens de acesso? Precisamos configurar o Provider dos tokens
                Provider = new ProviderTokenAccess()
            };

            //Estas duas linhas ativam o fornecimento de tokens de acesso numa WebApi
            app.UseOAuthAuthorizationServer(optionsConfigurationToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

    }
}
