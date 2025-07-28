using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Shapes.Services.Interfaces;
using Shapes.Shapes;

namespace Shapes.Services
{
    public class XmlReaderService : IWriterService
    {
        private readonly ISerializer serializer;
        private readonly XmlWriter writer;
        private readonly XmlReader reader;
        private const string FilePath = "shapes.xml";

        public XmlReaderService(ISerializer serializer)
        {
            this.serializer = serializer;
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                OmitXmlDeclaration = true
            };
            writer = XmlWriter.Create(FilePath, settings);
            reader = XmlReader.Create(FilePath);
        }

        public void Save(List<Shape> shapes)
        {
            serializer.Serialize(writer, shapes);
        }

        public List<Shape> Load()
        {
            var shapes = serializer.Deserialize(reader);
            return shapes.ToList();
        }
    }
}
