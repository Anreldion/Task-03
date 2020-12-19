using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using static ClassLibrary.Colors;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// Фигуры из пленки бесцветные и красить их нельзя.
    /// </summary>
    public class Film : Material
    {
        public Film()
        {
            colorationBehaviour = new NoColoring();
        }

        public override string ToString()
        {
            return "Film";
        }
    }
}
