using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Project
{
    [XmlInclude(typeof(Plug))]
    public class Plug
    {
        [XmlElement("BlockConnector")]
        public BlockConnector blockConnectors { get; set; }
    }
}
