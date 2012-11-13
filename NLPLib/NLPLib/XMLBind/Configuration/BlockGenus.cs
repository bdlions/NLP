using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Configuration
{
    [XmlInclude(typeof(BlockGenus))]
    public class BlockGenus
    {
        public int id { get; set; }

        [XmlAttribute("name")]
        public String name { get; set; }
  
        [XmlAttribute("kind")]
        public String kind { get; set; }

        [XmlAttribute("initlabel")]
        public String initlabel { get; set; }

        [XmlAttribute("editable-label")]
        public String editableLabel { get; set; }

        [XmlAttribute("is-label-value")]
        public String isLabeValue { get; set; }

        [XmlAttribute("color")]
        public String color { get; set; }

        [XmlAttribute("label-prefix")]
        public String labelPrefix { get; set; }

        [XmlAttribute("label-suffix")]
        public String labelSuffix { get; set; }

        [XmlAttribute("page-label-enabled")]
        public String pageLabelEnabled { get; set; }

        [XmlAttribute("is-starter ")]
        public String isStarter  { get; set; }

        [XmlAttribute("is-terminator")]
        public String isTerminator { get; set; }

        [XmlArray("BlockConnectors")]
        public List<BlockConnector> blockConnectors { get; set; }

        public bool isVariableDeclBlock()
        {
            if (kind.Equals("variable")) return true;
            return false;
        }

        public bool isDataBlock()
        {
            if (kind.Equals("data")) return true;
            return false;
        }

        public bool isCommandBlock()
        {
            if (kind.Equals("command")) return true;
            return false;
        }

        public bool isFunctionBlock()
        {
            if (kind.Equals("function")) return true;
            return false;
        }

    }
}
