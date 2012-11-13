using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Configuration
{
    [XmlInclude(typeof(DefaultArg))]
    public class DefaultArg
    {
        [XmlAttribute("genus-name")]
        public String genusName { get; set; }

        [XmlAttribute("label")]
        public String label { get; set; }
    }
}
