using System.Collections.Generic;
using Shapes.Shapes;

namespace Shapes.Services.Interfaces
{
    public interface IWriterService
    {
        void Save(List<Shape> shapes);
        List<Shape> Load();
    }
}
