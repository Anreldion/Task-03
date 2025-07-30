using Shapes.Sheets;

namespace Shapes.Shapes
{
    /// <summary>
    /// Represents a square shape defined by the length of its side.
    /// </summary>
    public class Square : Shape
    {
        /// <summary>
        /// Gets or sets the length of the side of the square.
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// Gets the material the square is made from.
        /// </summary>
        public override Material Material { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// Required for XML serialization.
        /// </summary>
        public Square() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class with a given side length and material.
        /// </summary>
        /// <param name="side">Length of the side.</param>
        /// <param name="material">Material of the square.</param>
        public Square(double side, Material material)
        {
            Side = side;
            Material = material;
        }

        /// <summary>
        /// Calculates and returns the perimeter of the square.
        /// </summary>
        public override double GetPerimeter() => Side * 4;

        /// <summary>
        /// Calculates and returns the area of the square.
        /// </summary>
        public override double GetArea() => Side * Side;
    }
}