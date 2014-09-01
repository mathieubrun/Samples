using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Routing;

namespace Samples.Web.EmbeddedResourceDemo
{
    public class EmbeddedResourceHandler : DelegatingHandler
    {
        private readonly Assembly assembly;

        public EmbeddedResourceHandler(Assembly assembly)
        {
            this.assembly = assembly;
        }

        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                HttpResponseMessage response = task.Result;

                var ctx = request.GetRequestContext();

                var path = ctx.RouteData.Values["path"] as string;

                var str = assembly.GetManifestResourceStream(assembly.GetName().Name + "." + path.Replace("/", "."));

                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Content = new StreamContent(str);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(Path.GetFileName(path)));

                return response;
            });
        }
    }
}