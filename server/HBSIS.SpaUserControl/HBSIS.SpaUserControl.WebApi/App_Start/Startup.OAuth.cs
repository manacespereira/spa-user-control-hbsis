using System;
using HBSIS.SpaUserControl.WebApi.Security;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace HBSIS.SpaUserControl.WebApi
{
    public partial class StartUp
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/authtoken"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationProvider(),
                RefreshTokenProvider =  new RefreshTokenProvider()
            };


            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}