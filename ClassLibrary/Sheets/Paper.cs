using Shapes.ColorationInterface;
using static Shapes.Colors;

namespace Shapes.Sheets
{
    /// <summary>
    /// Бумажные фигуры можно красить, но только 1 раз.
    /// </summary>
    public class Paper : Material
    {
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Paper()
        {
            colorationBehaviour = new ColoringOnce();
        }
        /// <summary>
        /// Конструктор с указанием цвета
        /// </summary>
        /// <param name="color"></param>
        public Paper(Palette color)
        {
            colorationBehaviour = new ColoringOnce();
            colorationBehaviour.Paint(color);
        }
        /// <summary>
        /// Получить строковое представление материала
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Paper";
        }
    }
}
