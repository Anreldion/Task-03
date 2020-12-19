using static ClassLibrary.Colors;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// Интерфейс. Поведение при окрашивании
    /// </summary>
    public interface IColoration
    {
        /// <summary>
        /// Окрашено?
        /// </summary>
        bool IsPainted { get; }

        /// <summary>
        /// Цвет
        /// </summary>
        Palette Color { get; }

        /// <summary>
        /// Окрасить
        /// </summary>
        /// <param name="сolor">Цвет покраски</param>
        void Paint(Palette color);
    }
}
