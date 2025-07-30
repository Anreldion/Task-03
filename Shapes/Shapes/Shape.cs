using Shapes.Extensions;
using Shapes.Sheets;
using System;
using System.Xml.Serialization;

namespace Shapes.Shapes
{
    /// <summary>
    /// Represents an abstract geometric shape with area, perimeter, and material.
    /// </summary>
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Square))]
    public abstract class Shape
    {
        private const double Tolerance = 0.01;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// Required for XML serialization.
        /// </summary>
        protected Shape() { }

        /// <summary>
        /// Gets the material from which the shape is made.
        /// </summary>
        public abstract Material Material { get; }

        /// <summary>
        /// Calculates and returns the area of the shape.
        /// </summary>
        public abstract double GetArea();

        /// <summary>
        /// Calculates and returns the perimeter of the shape.
        /// </summary>
        public abstract double GetPerimeter();

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Material, GetArea(), GetPerimeter());
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Shape Type: {GetType().Name}, Area: {GetArea():F2}, Perimeter: {GetPerimeter():F2}, Material: {Material}, Color: {Material.GetColor()}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not Shape other) return false;

            return Material.Equals(other.Material)
                && GetArea().EqualTo(other.GetArea(), Tolerance)
                && GetPerimeter().EqualTo(other.GetPerimeter(), Tolerance);
        }
    }
}
