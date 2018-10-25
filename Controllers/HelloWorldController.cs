using System;
using System.Collections.Generic;

namespace Microsoft.Examples.Controllers
{
    using System.Web.Http;

    // breaks
    //[Microsoft.Web.Http.ApiVersion("1.0")]
    //[RoutePrefix( "api/v{version:apiVersion}/helloworld" )]

    // working
    [RoutePrefix("api/v1/helloworld")]
    public class HelloWorldController : ApiController
    {
        [Route]
        public IHttpActionResult Get([FromUri] IEnumerable<Guid> ids)
        {
            return Ok($"ids is null: {ids == null}");
        }
    }
}