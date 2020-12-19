using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using static ClassLibrary.Colors;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// Фигуры из пластика можно многократно перекрашивать. 
    /// </summary>
    public class Plastic : Material
    {
        public Plastic()
        {
            colorationBehaviour = new ColoringMultiple();
        }

        public Plastic(Palette color)
        {
            colorationBehaviour = new ColoringMultiple();
            colorationBehaviour.Paint(color);
        }

        public override string ToString()
        {
            return "Plastic";
        }
    }
}
