using Shapes.Enums;
using Shapes.Exceptions;

namespace Shapes.Sheets
{
    /// <summary>
    /// Бумажные фигуры можно красить, но только 1 раз.
    /// </summary>
    public class Paper : Material
    {
        public Paper() { }
        public override void Paint(Colors color)
        {
            if (IsPainted())
            {
                throw new PaintException("Paper is already painted.");
            }

            Color = color;
        }
    }
}
