using Shapes.Enums;
using Shapes.Exceptions;

namespace Shapes.Sheets
{
    /// <summary>
    /// Фигуры из пленки бесцветные и красить их нельзя.
    /// </summary>
    public class Film : Material
    {
        public Film() { }
        public override void Paint(Colors color)
        {
            throw new PaintException("Film is not paintable");
        }
    }
}
