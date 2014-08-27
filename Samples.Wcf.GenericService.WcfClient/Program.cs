using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samples.Wcf.GenericService.WcfInterfaces;
using System.ServiceModel;

namespace Samples.Wcf.GenericService.WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var binding = new BasicHttpBinding();
            var endpointBase = new EndpointAddress("http://localhost:4444/BaseService.svc");
            var endpointSpecific = new EndpointAddress("http://localhost:4444/SpecificService.svc");

            using (var channelFactory = new ChannelFactory<IGenericService<EntityBase>>(binding, endpointBase))
            {
                var serviceChannel = channelFactory.CreateChannel();
                var data = serviceChannel.GetEntity("Hello world!");
                Console.WriteLine(data.Text);
            }

            using (var channelFactory = new ChannelFactory<IGenericService<SpecificEntity>>(binding, endpointSpecific))
            {
                var serviceChannel = channelFactory.CreateChannel();
                var data = serviceChannel.GetEntity("Hello world!");
                Console.WriteLine(data.Text);
                Console.WriteLine(data.AdditionalText);
            }
        }
    }
}
