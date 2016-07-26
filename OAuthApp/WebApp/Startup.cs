using Microsoft.Owin;
using Owin;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServer3.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions()
            {
                Authority = "http://localhost:5000",
                ValidationMode = IdentityServer3.AccessTokenValidation.ValidationMode.ValidationEndpoint, 
                RequiredScopes = new[] { "api1" }
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }
    }
}
