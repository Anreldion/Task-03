using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class ExceptionsClass
    {
        public class BoxExceptions : Exception
        {
            public BoxExceptions(string message) : base(message)
            {

            }
        }
        public class BoxArgumentException : ArgumentException
        {
            public int Value { get; }
            public BoxArgumentException(string message, int val) : base(message)
            {
                Value = val;
            }
        }
        public class SheetExceptions : Exception
        {
            public SheetExceptions(string message) : base(message)
            {

            }
        }
        public class ShapeExceptions : Exception
        {
            public ShapeExceptions(string message) : base(message)
            {

            }
        }
        public class XmlExceptions : Exception
        {
            public XmlExceptions(string message) : base(message)
            {

            }
        }
    }
}
