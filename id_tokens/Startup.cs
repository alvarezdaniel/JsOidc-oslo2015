using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(JavaScriptImplicitClient_Simple.Startup))]

namespace JavaScriptImplicitClient_Simple
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new Thinktecture.IdentityServer.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44333/core",
                RequiredScopes = new string[] { "api1" }
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new AuthorizeAttribute());
            app.UseWebApi(config);
        }
    }
}
