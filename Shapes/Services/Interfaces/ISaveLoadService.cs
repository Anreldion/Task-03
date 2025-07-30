using System.Collections.Generic;
using Shapes.Shapes;

namespace Shapes.Services.Interfaces
{
    public interface ISaveLoadService
    {
        void Save(string path, List<Shape> shapes);
        List<Shape> Load(string path);
    }
}
