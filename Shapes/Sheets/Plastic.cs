using Shapes.Enums;

namespace Shapes.Sheets
{
    /// <summary>
    /// Represents a material made of plastic, which can be painted and repainted.
    /// </summary>
    public class Plastic : Material
    {
        public override void Paint(Colors color)
        {
            Color = color;
        }
    }
}
