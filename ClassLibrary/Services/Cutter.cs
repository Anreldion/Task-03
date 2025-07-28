using Shapes.Exceptions;
using Shapes.Shapes;
using System;

namespace Shapes.Services
{
    public static class Cutter
    {
        /// <summary>
        /// Attempts to cut a new figure from an existing one, based on the area comparison.
        /// </summary>
        /// <param name="source">The source figure from which to cut.</param>
        /// <param name="createTarget">
        /// A delegate that creates the target figure. The target must have a smaller area than the source.
        /// </param>
        /// <returns>
        /// A new figure created by <paramref name="createTarget"/>, if its area is less than the source figure's area.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="source"/> or <paramref name="createTarget"/> is null.
        /// </exception>
        /// <exception cref="CutException">
        /// Thrown when the area of the target figure is greater than the area of the source figure.
        /// </exception>
        /// <example>
        /// <code>
        /// var source = new Circle(new Material(MaterialType.Paper), radius: 10);
        /// 
        /// var cut = Cutter.Cut(source, () => new Rectangle(
        ///     new Material(MaterialType.Paper), width: 5, height: 3
        /// ));
        /// 
        /// Console.WriteLine($"Cut a rectangle with area {cut.GetArea()} from a circle with area {source.GetArea()}");
        /// </code>
        /// </example>
        public static Shape Cut(Shape source, Func<Shape> createTarget)
        {
            if (source == null || createTarget == null)
                throw new ArgumentNullException();

            var target = createTarget();

            if (target.GetArea() > source.GetArea())
                throw new CutException("Target figure is larger than the source.");

            return target;
        }
    }
}
