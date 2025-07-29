using System;

namespace Shapes.Exceptions
{
    public class FigureNotFoundException : Exception
    {
        public FigureNotFoundException() { }

        public FigureNotFoundException(string message) : base(message) { }

        public FigureNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
