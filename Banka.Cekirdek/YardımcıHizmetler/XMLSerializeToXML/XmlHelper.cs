using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Banka.Cekirdek.YardımcıHizmetler.XMLSerializeToXML
{
    public static class XmlHelper
    {
        public static string SerializeToXml<T>(T obj)
        {
            if (obj == null)
                return string.Empty;

            var serializer = new XmlSerializer(typeof(T));
            using var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, obj);
            return stringWriter.ToString();
        }
    }
}
