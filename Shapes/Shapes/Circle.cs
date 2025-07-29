using System;
using Shapes.Enums;
using Shapes.Sheets;

namespace Shapes.Shapes
{
    public class Circle : Shape
    {
        private readonly double _radius;
        public override Material Material { get; }

      
        public Circle(Material material, double radius)
        {
            _radius = radius;
            Material = material;
        }
       
        public override double GetPerimeter()
        {
            var perimeter = 2 * Math.PI * _radius;
            if (double.IsNaN(perimeter))
            {
                return 0;
            }
            return perimeter;
        }
        
        public override double GetArea()
        {
            var area = Math.PI * (_radius * _radius);
            if (double.IsNaN(area))
            {
                return 0;
            }
            return area;
        }

        public override void Paint(Colors color)
        {
            Material.Paint(color);
        }
    }
}
