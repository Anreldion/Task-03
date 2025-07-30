using Shapes.Sheets;

namespace Shapes.Shapes
{
    /// <summary>
    /// Represents a rectangle shape defined by its width and height.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets the material the rectangle is made from.
        /// </summary>
        public override Material Material { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// Required for XML serialization.
        /// </summary>
        public Rectangle() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class with specified material, width, and height.
        /// </summary>
        /// <param name="material">The material of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(Material material, double width, double height)
        {
            Material = material;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Calculates and returns the perimeter of the rectangle.
        /// </summary>
        public override double GetPerimeter()
        {
            var perimeter = 2 * (Width + Height);
            return double.IsNaN(perimeter) ? 0 : perimeter;
        }

        /// <summary>
        /// Calculates and returns the area of the rectangle.
        /// </summary>
        public override double GetArea()
        {
            var area = Width * Height;
            return double.IsNaN(area) ? 0 : area;
        }
    }
}
