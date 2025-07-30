using Shapes.Sheets;
using System;

namespace Shapes.Shapes
{
    /// <summary>
    /// Represents a triangle shape defined by three sides.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Gets or sets the length of side A.
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// Gets or sets the length of side B.
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Gets or sets the length of side C.
        /// </summary>
        public double C { get; set; }

        /// <summary>
        /// Gets the material the triangle is made from.
        /// </summary>
        public override Material Material { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// Required for XML serialization.
        /// </summary>
        public Triangle() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class with specified side lengths and material.
        /// </summary>
        /// <param name="a">Length of side A.</param>
        /// <param name="b">Length of side B.</param>
        /// <param name="c">Length of side C.</param>
        /// <param name="material">Material of the triangle.</param>
        /// <exception cref="ArgumentException">Thrown when the provided sides do not form a valid triangle.</exception>
        public Triangle(double a, double b, double c, Material material)
        {
            A = a;
            B = b;
            C = c;

            if (A + B <= C || A + C <= B || B + C <= A)
                throw new ArgumentException("Invalid triangle sides.");

            Material = material;
        }

        /// <summary>
        /// Calculates and returns the perimeter of the triangle.
        /// </summary>
        public override double GetPerimeter()
        {
            var perimeter = A + B + C;
            return double.IsNaN(perimeter) ? 0 : perimeter;
        }

        /// <summary>
        /// Calculates and returns the area of the triangle using Heron's formula.
        /// </summary>
        public override double GetArea()
        {
            var semiPerimeter = GetPerimeter() / 2;
            var area = Math.Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
            return double.IsNaN(area) ? 0 : area;
        }
    }
}
