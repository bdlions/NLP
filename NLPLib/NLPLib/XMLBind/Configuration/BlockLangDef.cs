using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NLPLib.XMLBind.Configuration
{
    [XmlRoot("BlockLangDef")]
    public class BlockLangDef
    {
        [XmlArray("BlockGenuses")]
        public List<BlockGenus> blockGenuses { get; set; }

        [XmlArray("BlockFamilies")]
        public List<BlockFamily> blockFamilies { get; set; }

        [XmlArray("BlockDrawerSets")]
        public List<BlockDrawerSet> blockDrawerSets { get; set; }
    }
}
