using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Project
{
    [XmlInclude(typeof(Page))]
    public class Page
    {
        [XmlAttribute("page-name")]
        public String pageName { set; get; }

        [XmlArray("PageBlocks")]
        public List<Block> pageBlocks { set; get; }
    }
}
