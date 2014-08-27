using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Samples.Wcf.GenericService.WcfInterfaces
{
    [DataContract]
    public class EntityBase
    {
        [DataMember]
        public string Text { get; set; }

        public virtual void Initialize()
        { 
        }
    }
}
