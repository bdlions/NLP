using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Configuration
{
    [XmlInclude(typeof(BlockDrawerSet))]
    public class BlockDrawerSet
    {
        [XmlAttribute("type")]
        public String type { get; set; }

        [XmlAttribute("FamilyMember")]
        public String familyMember { get; set; }

        [XmlAttribute("name")]
        public String name { get; set; }

        [XmlAttribute("location")]
        public String location { get; set; }

        [XmlAttribute("window-per-drawer")]
        public String windowPerDrawer { get; set; }

        [XmlAttribute("drawer-draggable")]
        public String drawerDraggable { get; set; }

        [XmlAttribute("width")]
        public String width { get; set; }

        [XmlElement(ElementName = "BlockDrawer")]
        public List<BlockDrawer> blockDrawer { get; set; }
    }
}
