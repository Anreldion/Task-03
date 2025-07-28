using System;
using System.Collections.Generic;
using Shapes.Sheets;
using static Shapes.Colors;

namespace Shapes.Shapes
{
    public abstract class Shape
    {
        private const double Tolerance = 0.01;
        protected Shape() { }

        /// <summary>
        /// Материал фигуры
        /// </summary>
        public abstract Material Material { get; }

        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public abstract double GetArea();

        /// <summary>
        /// Периметр фигуры
        /// </summary>
        public abstract double GetPerimeter();

        /// <summary>
        /// Окрасить фигуру
        /// </summary>
        /// <param name="color">Цвет палитры</param>
        public abstract void Paint(Palette color);
        public override int GetHashCode()
        {
            return HashCode.Combine(Material, GetArea(), GetPerimeter());
        }

        public override string ToString()
        {
            return string.Format("Тип: {4}, Площадь: {0:f2}, Периметр: {1:f2}, Материал: {2}, Цвет: {3}", GetArea(), GetPerimeter(), Material.ToString(), Material.GetColor().ToString());
        }

        public override bool Equals(object obj)
        {
            return obj is Shape @base &&
                   EqualityComparer<Material>.Default.Equals(Material, @base.Material) &&
                   GetArea().EqualTo(@base.GetArea(), Tolerance) &&
                   GetPerimeter().EqualTo(@base.GetPerimeter(), Tolerance);
        }


    }
}
