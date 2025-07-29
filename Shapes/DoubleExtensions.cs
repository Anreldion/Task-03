using System;

namespace Shapes
{
    /// <summary>
    /// Дополнения для Double
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Сравнить double значения, с определенной точностью
        /// </summary>
        /// <param name="value1">Первое значение</param>
        /// <param name="value2">Второе значение</param>
        /// <param name="delta">Диапазон разбежки между двумя значениями</param>
        /// <returns>true если числа равны, иначе false</returns>
        public static bool EqualTo(this double value1, double value2, double delta)
        {
            return Math.Abs(value1 - value2) < delta;
        }
    }

}
