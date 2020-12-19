using System.Drawing;
using System.IO;
using System.Xml;
using static ClassLibrary.Colors;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// 
    /// </summary>
    public class ColoringMultiple : IColoration
    {
        private bool isPainted;
        private Palette color;
        public bool IsPainted { get { return isPainted; } }
        public Palette Color { get { return color; } }


        public void Paint(Colors.Palette color)
        {
            isPainted = true;
            this.color = color;
        }

        public void ToStreamWriter(StreamWriter streamWriter)
        {
            throw new System.NotImplementedException();
        }
    }
}
