using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Samples.Wcf.GenericService.WcfInterfaces
{
    [DataContract]
    public class SpecificEntity : EntityBase
    {
        [DataMember]
        public string AdditionalText { get; set; }

        public override void Initialize()
        {
            AdditionalText = Text + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
