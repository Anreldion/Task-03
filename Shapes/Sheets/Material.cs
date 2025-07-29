using Shapes.Enums;

namespace Shapes.Sheets
{
   public abstract class Material
    {
        internal Colors Color { get; set; }

        public abstract void Paint(Colors color);

        public bool IsPainted()
        {
            return Color != Colors.None;
        }
        public Colors GetColor()
        {
            return Color;
        }
    }
}
