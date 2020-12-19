using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using static ClassLibrary.Colors;

namespace ClassLibrary.Sheets
{

    /// <summary>
    /// Абстрактный класс - Материал.
    /// </summary>
    public abstract class  Material
    {
        /// <summary>
        /// Поведение при окрашивании
        /// </summary>
        protected IColoration colorationBehaviour;

        public abstract string ToString();

        public void Paint(Colors.Palette color)
        {
            colorationBehaviour.Paint(color);
        }
        public bool IsPainted()
        {
            return colorationBehaviour.IsPainted;
        }
        public Palette GetColor()
        {
            return colorationBehaviour.Color;
        }

        public string GetColorationBehaviour()
        {
            return colorationBehaviour.ToString();
        }

    }

    public class Materials
    {
        public static Film Film = new Film();
        public static Paper Paper = new Paper();
        public static Plastic Plastic = new Plastic();
    }
}
