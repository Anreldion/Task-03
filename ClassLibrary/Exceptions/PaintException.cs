using System;

namespace Shapes.Exceptions
{
    public class PaintException : Exception
    {
        public PaintException() { }

        public PaintException(string message) : base(message) { }

        public PaintException(string message, Exception inner) : base(message, inner) { }
    }
}
