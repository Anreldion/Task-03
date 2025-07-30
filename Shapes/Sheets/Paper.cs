using Shapes.Enums;
using Shapes.Exceptions;

namespace Shapes.Sheets
{
    /// <summary>
    /// Represents a material made of paper, which can be painted only once.
    /// </summary>
    public class Paper : Material
    {
        public override void Paint(Colors color)
        {
            if (IsPainted())
                throw new PaintException("Paper is already painted.");

            Color = color;
        }
    }
}
