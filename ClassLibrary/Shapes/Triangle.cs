using System;
using Shapes.Sheets;

namespace Shapes.Shapes
{
    public class Triangle : Shape
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;
        private readonly Material _material;
        public override Material Material => _material;

        public Triangle(double a, double b, double c, Material material)
        {
            _a = a;
            _b = b;
            _c = c;
            _material = material;
        }

        public override double GetPerimeter()
        {

            var perimeter = _a + _b + _c;
            if (double.IsNaN(perimeter))
            {
                return 0;
            }
            return perimeter;

        }

        public override double GetArea()
        {

            var semiPerimeter = (_a + _b + _c) / 2;
            var area = Math.Sqrt(semiPerimeter * (semiPerimeter - _a) * (semiPerimeter - _b) * (semiPerimeter - _c));
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
