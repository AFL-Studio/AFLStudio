using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace AFLCommonLibNamespace
{
    public class AFLCommonLib
    {

        public AFLCommonLib()
        {
            // Constructor
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToString(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="strSerializedString"></param>
        /// <returns></returns>
        public static object? DeserializeFromString<T>(string strSerializedString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return serializer.Deserialize(new StringReader(strSerializedString));
        }

    }
}