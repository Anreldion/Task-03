using static ClassLibrary.Colors;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// Множественное окрашивание. Реализвация интерфейса
    /// </summary>
    public class ColoringMultiple : IColoration
    {
        private bool isPainted;
        private Palette color;
        /// <summary>
        /// Окрашено?
        /// </summary>
        public bool IsPainted { get { return isPainted; } }
        /// <summary>
        /// Получить цвет
        /// </summary>
        public Palette Color { get { return color; } }

        /// <summary>
        /// Окрасить
        /// </summary>
        /// <param name="color">Набор Palette</param>
        public void Paint(Palette color)
        {
            isPainted = true;
            this.color = color;
        }
        public override string ToString()
        {
            return "ColoringMultiple";
        }
    }
}
