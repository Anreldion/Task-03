using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Shapes.Services.Interfaces;
using Shapes.Shapes;

namespace Shapes.Services
{
    public class StreamReaderService : ISaveLoadService
    {
        private readonly ISerializer _serializer;

        public StreamReaderService(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public void Save(string path, List<Shape> shapes)
        {
            using var writer = new StreamWriter(path, false, Encoding.UTF8);
            _serializer.Serialize(writer, shapes);
        }

        public List<Shape> Load(string path)
        {
            using var reader = new StreamReader(path, Encoding.UTF8);
            return _serializer.Deserialize(reader).ToList();
        }
    }
}
