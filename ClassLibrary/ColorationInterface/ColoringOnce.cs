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
    public class ColoringOnce : IColoration
    {
        private bool isPainted;
        private Palette color;

        public bool IsPainted { get { return isPainted; } }

        public Palette Color { get { return color; } }

        public void Paint(Palette color)
        {
            if (IsPainted)
            {
                throw new SheetExceptions("Фигура окрашена, повторное окрашивание невозможно!");
            }
            else
            {
                isPainted = true;
                this.color = color;
            }
        }

        public override string ToString()
        {
            return "ColoringOnce";
        }
    }
}
