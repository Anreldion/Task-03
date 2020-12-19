using System;
using System.Drawing;
using System.IO;
using System.Xml;
using static ClassLibrary.Colors;
using static ClassLibrary.ExceptionsClass;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// 
    /// </summary>
    public class NoColoring : IColoration
    {
        private bool isPainted;
        private Palette color;
        public bool IsPainted { get { return isPainted; } }

        public Palette Color { get { return color; } }

        public void Paint(Palette color)
        {
            throw new SheetExceptions("Окрашивание невозможно!");
        }

        public override string ToString()
        {
            return "NoColoring";
        }
    }
}
