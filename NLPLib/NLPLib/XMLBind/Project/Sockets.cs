using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Project
{
    [XmlInclude(typeof(Sockets))]
    public class Sockets
    {
        [XmlAttribute("num-sockets")]
        public int numSockets { get; set; }
        [XmlArray("BlockConnector")]
        public List<BlockConnector> blockConnectors { get; set; }
    }
}
