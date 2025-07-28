using Shapes.Sheets;

namespace Shapes.Shapes
{
    public class Rectangle : Shape
    {

        private readonly double _width;
        private readonly double _height;
        public override Material Material { get; }
    
        public Rectangle(Material material, double width, double height)
        {
            Material = material;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Периметр прямоугольника
        /// </summary>
        public override double GetPerimeter()
        {
            var perimeter = 2 * (_width + _height);
            if (double.IsNaN(perimeter))
            {
                return 0;
            }
            return perimeter;
        }

        /// <summary>
        /// Площадь прямоугольника
        /// </summary>
        public override double GetArea()
        {
            var area = _width * _height;
            if (double.IsNaN(area))
            {
                return 0;
            }
            return area;
        }

        /// <summary>
        /// Окрасить фигуру
        /// </summary>
        /// <param name="color">Цвет окрашивания</param>
        public override void Paint(Colors.Palette color)
        {
            Material.Paint(color);
        }
    }
}
