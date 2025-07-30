using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Shapes.Services.Interfaces;
using Shapes.Shapes;

namespace Shapes.Services
{
    public class XmlReaderService : ISaveLoadService
    {
        private readonly ISerializer _serializer;
        private readonly XmlWriterSettings _settings;

        public XmlReaderService(ISerializer serializer)
        {
            _serializer = serializer;
            _settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                OmitXmlDeclaration = true,
                Indent = true
            };
        }

        public void Save(string path, List<Shape> shapes)
        {
            using var writer = XmlWriter.Create(path, _settings);
            _serializer.Serialize(writer, shapes);
        }

        public List<Shape> Load(string path)
        {
            using var reader = XmlReader.Create(path);
            return _serializer.Deserialize(reader).ToList();
        }
    }
}
