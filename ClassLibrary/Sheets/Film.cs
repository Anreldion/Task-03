using Shapes.ColorationInterface;

namespace Shapes.Sheets
{
    /// <summary>
    /// Фигуры из пленки бесцветные и красить их нельзя.
    /// </summary>
    public class Film : Material
    {
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Film()
        {
            colorationBehaviour = new NoColoring();
        }
        /// <summary>
        /// Получить строковое представление материала
        /// </summary>
        /// <returns>Строковое представление материала</returns>
        public override string ToString()
        {
            return "Film";
        }
    }
}
