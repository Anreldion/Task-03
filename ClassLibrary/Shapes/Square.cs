using System;
using Shapes.Sheets;

namespace Shapes.Shapes
{
    public class Square : Shape
    {
        private readonly double _side;
        private readonly Material _material;
        
        public override Material Material => _material;

        public Square(double side, Material material)
        {
            _side = side;
            _material = material;
        }
        
        public override double GetPerimeter()
        {
            var perimeter = _side * 4;
            if (double.IsNaN(perimeter))
            {
                return 0;
            }
            return perimeter;
        }

        public override double GetArea()
        {
            var area = _side * _side;
            if (double.IsNaN(area))
            {
                return 0;
            }
            return area;
        }

        public override void Paint(Colors.Palette color)
        {
            _material.Paint(color);
        }
    }
}
