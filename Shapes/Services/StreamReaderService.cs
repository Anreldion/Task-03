using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Shapes.Services.Interfaces;
using Shapes.Shapes;

namespace Shapes.Services
{
    public class StreamReaderService : IWriterService
    {
        private readonly ISerializer _serializer;
        private const string FilePath = "shapes.xml";

        public StreamReaderService(ISerializer serializer)
        {
            this._serializer = serializer;
        }

        public void Save(List<Shape> shapes)
        {
            using var streamWriter = new StreamWriter(FilePath, false, Encoding.UTF8);
            _serializer.Serialize(streamWriter, shapes);
        }

        public List<Shape> Load()
        {
            using var streamReader = new StreamReader(FilePath, Encoding.UTF8);
            var shapes = _serializer.Deserialize(streamReader);
            return shapes.ToList();
        }
    }
}
