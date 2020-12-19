using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using static ClassLibrary.Colors;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// Бумажные фигуры можно красить, но только 1 раз.
    /// </summary>
    public class Paper : Material
    {
        public Paper()
        {
            colorationBehaviour = new ColoringOnce();
        }

        public Paper(Palette color)
        {
            colorationBehaviour = new ColoringOnce();
            colorationBehaviour.Paint(color);
        }

        public override string ToString()
        {
            return "Paper";
        }
    }
}
