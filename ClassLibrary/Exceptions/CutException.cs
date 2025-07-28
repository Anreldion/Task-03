using System;

namespace Shapes.Exceptions
{
    public class CutException : Exception
    {
        public CutException() { }

        public CutException(string message) : base(message) { }

        public CutException(string message, Exception inner) : base(message, inner) { }
    }
}
