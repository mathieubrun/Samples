using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Routing;

namespace Samples.Web.EmbeddedResourceDemo
{
    public class EmbeddedResourceHandler : HttpMessageHandler
    {
        private readonly string assembly;

        public EmbeddedResourceHandler(string assembly)
        {
            this.assembly = assembly;
        }

        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}