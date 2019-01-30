using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public const string Login = "adminAPI";
        public const string Pass = "devPartner@123";

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName != Login && context.Password != Pass)
            {
                context.SetError("invalid_grant", "Usuário/Senha inválidos.");
                return;
            }

            context.Validated(new ClaimsIdentity(context.Options.AuthenticationType));
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
    }
}