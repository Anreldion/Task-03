using Shapes.Sheets;
using System;

namespace Shapes.Shapes
{
    /// <summary>
    /// Represents a circle shape defined by its radius.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Gets the material the circle is made from.
        /// </summary>
        public override Material Material { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// Required for XML serialization.
        /// </summary>
        public Circle() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class with a given material and radius.
        /// </summary>
        /// <param name="material">The material of the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(Material material, double radius)
        {
            Radius = radius;
            Material = material;
        }

        /// <summary>
        /// Calculates and returns the perimeter (circumference) of the circle.
        /// </summary>
        public override double GetPerimeter() => 2 * Math.PI * Radius;

        /// <summary>
        /// Calculates and returns the area of the circle.
        /// </summary>
        public override double GetArea() => Math.PI * Radius * Radius;
    }
}