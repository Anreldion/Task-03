using static ClassLibrary.Colors;
using static ClassLibrary.ExceptionsClass;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// Однократное окрашивание. Реализвация интерфейса.
    /// </summary>
    public class ColoringOnce : IColoration
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
