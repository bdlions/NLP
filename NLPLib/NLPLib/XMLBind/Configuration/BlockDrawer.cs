using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Configuration
{
    [XmlInclude(typeof(BlockDrawer))]
    public class BlockDrawer
    {
        [XmlAttribute("name")]
        public String name { get; set; }

        [XmlAttribute("type")]
        public String type { get; set; }

        [XmlAttribute("is-open")]
        public String isOpen { get; set; }

        [XmlAttribute("button-color")]
        public String buttonColor { get; set; }

        [XmlElement(ElementName = "BlockGenusMember")]
        public List<String> blockGenusMember { get; set; }

    }
}
