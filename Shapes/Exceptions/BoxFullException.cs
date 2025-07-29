using System;

namespace Shapes.Exceptions
{
    public class BoxFullException : Exception
    {
        public BoxFullException() { }

        public BoxFullException(string message) : base(message) { }

        public BoxFullException(string message, Exception inner) : base(message, inner) { }
    }
}
