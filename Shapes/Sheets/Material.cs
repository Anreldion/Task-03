using Shapes.Enums;

namespace Shapes.Sheets
{
    /// <summary>
    /// Represents an abstract base class for a material from which a shape can be made.
    /// </summary>
    public abstract class Material
    {
        /// <summary>
        /// Gets the current color of the material.
        /// </summary>
        internal Colors Color { get; set; } = Colors.None;

        /// <summary>
        /// Paints the material with the specified color.
        /// Throws exception if painting is not allowed.
        /// </summary>
        /// <param name="color">The color to apply.</param>
        public abstract void Paint(Colors color);

        /// <summary>
        /// Checks whether the material has already been painted.
        /// </summary>
        public bool IsPainted() => Color != Colors.None;

        /// <summary>
        /// Returns the current color of the material.
        /// </summary>
        public Colors GetColor() => Color;

        public override string ToString() => GetType().Name;
    }
}
