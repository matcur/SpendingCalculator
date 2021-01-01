using SpendingCalculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SpendingCalculator.Core.Savers
{
    class XmlSaver : ISaver
    {
        public void Save<TSource>(TSource source, string filePath)
        {
            var type = typeof(TSource);
            var serializer = new XmlSerializer(type, type.Name);
            
            if (File.Exists(filePath))
                File.Delete(filePath);

            using (var file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(file, source);
            }
        }
    }
}
