using SpendingCalculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SpendingCalculator.Core.Loaders
{
    class XmlLoader : ILoader
    {
        public T Load<T>(string filePath)
        {
            var document = new XmlDocument();
            document.Load(filePath);

            return DeserializeNotes<T>(document);
        }

        private T DeserializeNotes<T>(XmlNode element)
        {
            var type = typeof(T);
            var serializer = new XmlSerializer(type, type.Name);
            using (var reader = new XmlNodeReader(element))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
