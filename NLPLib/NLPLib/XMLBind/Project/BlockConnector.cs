using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Project
{
    [XmlInclude(typeof(BlockConnector))]
    public class BlockConnector
    {
        [XmlAttribute("con-block-id")]
        public int connectBlockId { get; set; }
        [XmlAttribute("label")]
        public String label { get; set; }
        [XmlAttribute("init-type")]
        public String type { get; set; }
        [XmlAttribute("position-type")]
        public String positionType { get; set; }
    }
}
