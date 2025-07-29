using System.Collections.Generic;
using System.IO;
using System.Xml;
using Shapes.Shapes;

namespace Shapes.Services.Interfaces
{
    public interface ISerializer
    {
        IEnumerable<Shape> Deserialize(XmlReader reader);
        IEnumerable<Shape> Deserialize(StreamReader reader);
        void Serialize(XmlWriter writer, List<Shape> shapes);
        void Serialize(StreamWriter writer, List<Shape> shapes);
    }
}
