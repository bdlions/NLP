using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Configuration
{
    [XmlInclude(typeof(BlockConnector))]
    public class BlockConnector
    {
        [XmlAttribute("label")]
        public String label { get; set; }

        [XmlAttribute("label-editable")]
        public String labelEditable { get; set; }

        [XmlAttribute("connector-kind")]
        public String connectorKind { get; set; }

        [XmlAttribute("connector-type")]
        public String connectorType { get; set; }

        [XmlAttribute("position-type")]
        public String positionType { get; set; }

        [XmlAttribute("is-expandable")]
        public String isExpandable { get; set; }

        [XmlElement(ElementName = "DefaultArg")]
        public DefaultArg defaultArg { get; set; }
    }
}
