using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Samples.Wcf.GenericService.WcfInterfaces;

namespace Samples.Wcf.GenericService.WcfService
{
    public class GenericService<T> : IGenericService<T> where T : EntityBase, new()
    {
        public T GetEntity(string text)
        {
            var t = new T() { Text = text };
            t.Initialize();
            return t;
        }
    }
}
