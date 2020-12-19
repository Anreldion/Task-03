using System;
using System.Collections.Generic;
using static ClassLibrary.Colors;

namespace ClassLibrary.Sheets
{

    /// <summary>
    /// Абстрактный класс - Материал.
    /// </summary>
    public abstract class Material
    {
        /// <summary>
        /// Поведение при окрашивании
        /// </summary>
        protected IColoration colorationBehaviour;
        /// <summary>
        /// Покрасить материал
        /// </summary>
        /// <param name="color">Цвет из палитры</param>
        public void Paint(Palette color)
        {
            colorationBehaviour.Paint(color);
        }
        /// <summary>
        /// Окрашен ли материал
        /// </summary>
        /// <returns>true, иначе false</returns>
        public bool IsPainted()
        {
            return colorationBehaviour.IsPainted;
        }
        /// <summary>
        /// Получить цвет материала
        /// </summary>
        /// <returns>Palette</returns>
        public Palette GetColor()
        {
            return colorationBehaviour.Color;
        }
        /// <summary>
        /// Поведение при окрашивании
        /// </summary>
        /// <returns>Строка с названием класса реализующий интерфейс IColoration</returns>
        public string GetColorationBehaviour()
        {
            return colorationBehaviour.ToString();
        }

        /// <summary>
        /// Преобразование материала в строку
        /// </summary>
        /// <returns>Наменование материала</returns>
        public abstract string ToString();

        /// <summary>
        /// Проверка на равенство двух объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true, иначе false</returns>
        public override bool Equals(object obj)
        {
            return obj is Material material &&
                   EqualityComparer<IColoration>.Default.Equals(colorationBehaviour, material.colorationBehaviour);
        }
        /// <summary>
        /// Получить HashCode объекта
        /// </summary>
        /// <returns>Значение HashCode</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(colorationBehaviour);
        }
    }
}
