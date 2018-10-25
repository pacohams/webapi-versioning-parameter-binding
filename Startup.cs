using System.Web.Http.Routing;
using Microsoft.Web.Http;
using Microsoft.Web.Http.Routing;

[assembly: Microsoft.Owin.OwinStartup( typeof( Microsoft.Examples.Startup ) )]

namespace Microsoft.Examples
{
    using global::Owin;
    using System.Web.Http;

    public class Startup
    {
        public void Configuration( IAppBuilder builder )
        {
            var configuration = new HttpConfiguration();
            var httpServer = new HttpServer( configuration );


            // breaks:
            configuration.AddApiVersioning();
            var constraintResolver = new DefaultInlineConstraintResolver() { ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) } };
            configuration.MapHttpAttributeRoutes(constraintResolver);

            // defaut (works)
            //configuration.MapHttpAttributeRoutes();
            builder.UseWebApi( httpServer );
        }
    }
}