using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public const string USERNAME = "DevPartner";
        public const string PASSWORD = "Abc123@";

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName != USERNAME && context.Password != PASSWORD)
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