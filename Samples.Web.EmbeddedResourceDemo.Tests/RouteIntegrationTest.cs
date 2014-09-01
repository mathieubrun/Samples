using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using Owin;
using Newtonsoft.Json;
using Microsoft.Owin.Hosting;

namespace Samples.Web.EmbeddedResourceDemo.Tests
{
    [TestClass]
    public class RouteIntegrationTest
    {
        protected static readonly string BaseAddress = "http://localhost:9000/";
        private static IDisposable app;

        [TestMethod]
        public void Get_root_data() 
        {
            var content = GetString("EmbeddedResourceDemoData/Hello.txt");

            Assert.AreEqual("Hello from root", content);
        }

        [TestMethod]
        public void Get_nested_data()
        {
            var content = GetString("EmbeddedResourceDemoData/Some/Folder/Hierarchy/Hello.txt");

            Assert.AreEqual("Hello from nested folder", content);
        }

        /// <summary>
        /// Start the self hosted server once per assembly
        /// </summary>
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            app = WebApp.Start<Startup>(BaseAddress);
        }

        /// <summary>
        /// Do not forget to clean up !
        /// </summary>
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (app != null)
            {
                app.Dispose();
            }
        }

        protected string GetString(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(BaseAddress + url).Result;

                var str = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.StatusCode + " " + str);
                }

                return str;
            }
        }

        public class Startup
        {
            public void Configuration(IAppBuilder appBuilder)
            {
                var config = new HttpConfiguration();

                // usual registration
                WebApiConfig.Register(config);

                config.EnsureInitialized();

                // register WebAPI with OWIN
                appBuilder.UseWebApi(config);
            }
        }
    }
}
