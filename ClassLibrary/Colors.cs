using System;

namespace ClassLibrary
{
    /// <summary>
    /// Набор красок
    /// </summary>
    public class Colors
    {
        /// <summary>
        /// Цветовая палитра
        /// </summary>
        public enum Palette
        {
            Red = 0xFF0000,
            Orange = 0xFFA500,
            Yellow = 0xFFFF00,
            Green = 0x008000,
            Blue = 0x0000FF,
            LightBlue = 0xADD8E6,
            Violet = 0xEE82EE,
        }

        /// <summary>
        /// Проверка на существование
        /// </summary>
        /// <param name="type">Тип</param>
        /// <returns>Возвращает true - если существует, false - если не существует.</returns>
        public bool IsExcist(string type)
        {
            Array names = Enum.GetNames(typeof(Palette));
            foreach (var item in names)
            {
                if ((string)item == type)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
