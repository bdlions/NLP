using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Project
{
    [XmlRoot("CODEBLOCKS")]
    public class CodeBlocks
    {
        [XmlArray("Pages")]
        public List<Page> pages { get; set; }

    }
}
