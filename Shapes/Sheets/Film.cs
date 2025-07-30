using Shapes.Enums;
using Shapes.Exceptions;

namespace Shapes.Sheets
{
    /// <summary>
    /// Represents a material made of film, which cannot be painted.
    /// </summary>
    public class Film : Material
    {
        public override void Paint(Colors color)
        {
            throw new PaintException("Film is not paintable.");
        }
    }
}
