using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LionExAPI.TK.Utility
{
    public class XmlHelper
    {
        public static string SerializeXML(object obj)
        {
            XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings()
            {
                // If set to true XmlWriter would close MemoryStream automatically and using would then do double dispose
                // Code analysis does not understand that. That's why there is a suppress message.
                CloseOutput = false,
                Encoding = Encoding.UTF8,
                OmitXmlDeclaration = true,
                Indent = false
            };
            string xml = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                var writer = XmlWriter.Create(stream, xmlWriterSettings);

                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    xml = reader.ReadToEnd();
                }

            }

            return xml;
        }

        public static T DeserializeXml<T>(string str)
        {

            XmlDocument xdoc = new XmlDocument();
            try
            {
                xdoc.LoadXml(str);

                XmlNodeReader reader = new XmlNodeReader(xdoc.DocumentElement);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                object obj = ser.Deserialize(reader);
                return (T)obj;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
