using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Project
{
    [XmlInclude(typeof(Block))]
    public class Block
    {
        [XmlElement("Label")]
        public String label { get; set; }
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlAttribute("genus-name")]
        public String genusName { get; set; }
        [XmlElement("AfterBlockId")]
        public int afterBlockId { get; set; }
        [XmlElement("BeforeBlockId")]
        public int beforeBlockId { get; set; }
        [XmlElement("Sockets")]
        public Sockets sockets { get; set; }
        [XmlElement("Plug")]
        public Plug plug { get; set; }
    }
}
