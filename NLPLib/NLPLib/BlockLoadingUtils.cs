using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLPLib.XMLBind.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace NLPLib
{
    public static class BlockLoadingUtils
    {
        public static BlockLangDef blockLangDef { get; set; }
        public static int nextBlockId = 1;
        private static Dictionary<string, BlockGenus> blockStorage = new Dictionary<string, BlockGenus>();

        public static void loadLangDefBlocks(string langDefContent)
        {
            blockLangDef = (BlockLangDef)xmlDeserializeFromString(langDefContent, typeof(BlockLangDef));
            for (int i = 0; i < blockLangDef.blockGenuses.Count; i ++ )
            {
                blockLangDef.blockGenuses[i].id = nextBlockId;
                nextBlockId++;
                Console.WriteLine(blockLangDef.blockGenuses[i].name);
                blockStorage.Add(blockLangDef.blockGenuses[i].name, blockLangDef.blockGenuses[i]);
            }
        }

        public static BlockGenus getGenusWithName(string blockGenusName) 
        {
            if (blockStorage.ContainsKey(blockGenusName))
            {
                return blockStorage[blockGenusName];
            }

            return null;

        }

        private static string xmlSerializeToString(object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }

            return sb.ToString();
        }

        private static object xmlDeserializeFromString(string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
