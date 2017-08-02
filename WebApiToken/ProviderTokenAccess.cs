using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApiToken.Models;

namespace WebApiToken
{
    public class ProviderTokenAccess : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication
            (OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Encontrar o usuário (aqui você deverá acessar o seu repositorio ou o AD, dependende de como
            // quer validar seu usuário.
            var user = Users()
                .FirstOrDefault(x => x.Name == context.UserName
                                && x.Password == context.Password);

            // cancelando a emissão do token se o usuário 
            //não for encontrado
            if (user == null)
            {
                context.SetError("invalid_grant",
                    "Usuário não encontrado ou a senha está incorreta.");
                return;
            }

            // emitindo o token com informacoes extras
            // se o usuário existe
            var identyUser = new ClaimsIdentity(context.Options.AuthenticationType);
            identyUser.AddClaim(new Claim(ClaimTypes.Role, "user"));

            context.Validated(identyUser);
        }

        public static IEnumerable<User> Users()
        {
            return new List<User>
            {
                new User { Name = "Marcelo", Password = "admin" },
                new User { Name = "Joao", Password = "12345" },
                
            };
        }
    }
}