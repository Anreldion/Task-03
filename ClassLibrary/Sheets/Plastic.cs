using Shapes.Enums;

namespace Shapes.Sheets
{
    /// <summary>
    /// Фигуры из пластика можно многократно перекрашивать. 
    /// </summary>
    public class Plastic : Material
    {
        public Plastic() { }

        public override void Paint(Colors color)
        {
            Color = color;
        }
    }
}
