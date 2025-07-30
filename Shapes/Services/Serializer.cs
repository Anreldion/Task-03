using Shapes.Services.Interfaces;
using Shapes.Shapes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Shapes.Services
{
    /// <summary>
    /// Provides functionality to serialize and deserialize collections of <see cref="Product"/> objects
    /// using the Newtonsoft.Json library. Supports polymorphic types via TypeNameHandling.Auto.
    /// </summary>
    public class Serializer : ISerializer
    {
        private readonly XmlSerializer _serializer;
        public Serializer()
        {
            _serializer = new XmlSerializer(typeof(List<Shape>), new XmlRootAttribute("Shapes"));
        }

        public IEnumerable<Shape> Deserialize(XmlReader reader)
        {
            return _serializer.Deserialize(reader) as List<Shape> ?? Enumerable.Empty<Shape>();
        }

        public IEnumerable<Shape> Deserialize(StreamReader reader)
        {
            return _serializer.Deserialize(reader) as List<Shape> ?? Enumerable.Empty<Shape>();
        }

        public void Serialize(XmlWriter writer, List<Shape> shapes)
        {
            _serializer.Serialize(writer, shapes);
        }

        public void Serialize(StreamWriter writer, List<Shape> shapes)
        {
            _serializer.Serialize(writer, shapes);
        }
    }
}
