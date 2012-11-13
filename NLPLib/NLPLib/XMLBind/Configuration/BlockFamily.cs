using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Configuration
{
    [XmlInclude(typeof(BlockFamily))]
    public class BlockFamily
    {
        [XmlElement(ElementName = "FamilyMember")]
        public String familyMember { get; set; }
    }
}
