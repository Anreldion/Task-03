using static ClassLibrary.Colors;

namespace ClassLibrary.Sheets
{
    /// <summary>
    /// Фигуры из пластика можно многократно перекрашивать. 
    /// </summary>
    public class Plastic : Material
    {
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Plastic()
        {
            colorationBehaviour = new ColoringMultiple();
        }
        /// <summary>
        /// Конструктор с указанием цвета
        /// </summary>
        /// <param name="color"></param>
        public Plastic(Palette color)
        {
            colorationBehaviour = new ColoringMultiple();
            colorationBehaviour.Paint(color);
        }
        /// <summary>
        /// Получить строковое представление материала
        /// </summary>
        /// <returns>Строковое представление материала</returns>
        public override string ToString()
        {
            return "Plastic";
        }
    }
}
