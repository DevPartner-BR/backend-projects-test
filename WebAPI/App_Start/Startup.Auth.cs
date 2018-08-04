using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using WebAPI.Providers;

namespace WebAPI
{
    public partial class Startup
	{
        public void ConfigureAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions tokenConfig = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new ApplicationOAuthProvider()
            };

            app.UseOAuthAuthorizationServer(tokenConfig);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
	}
}