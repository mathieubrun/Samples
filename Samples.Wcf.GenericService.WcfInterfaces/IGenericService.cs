using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Samples.Wcf.GenericService.WcfInterfaces
{
    [ServiceContract]
    public interface IGenericService<T> where T : EntityBase, new()
    {
        [OperationContract]
        T GetEntity(string text);
    }
}
