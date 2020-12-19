using static ClassLibrary.Colors;
using static ClassLibrary.ExceptionsClass;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// Окрашивание невозможно. Реализвация интерфейса
    /// </summary>
    public class NoColoring : IColoration
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
            throw new SheetExceptions("Окрашивание невозможно!");
        }

        public override string ToString()
        {
            return "NoColoring";
        }
    }
}
