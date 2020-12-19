using ClassLibrary.Sheets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using static ClassLibrary.Colors;

namespace ClassLibrary
{
    public abstract class  ShapeBase
    {
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        protected ShapeBase()
        {

        }

        /// <summary>
        /// Материал фигуры
        /// </summary>
        public abstract Material Material { get; }

        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// Периметр фигуры
        /// </summary>
        public abstract double Perimeter { get; }

        /// <summary>
        /// Вырезать участок фигуры
        /// </summary>
        /// <param name="area"></param>
        public abstract void Cutting(double area);

        /// <summary>
        /// Окрасить фигуру
        /// </summary>
        /// <param name="color">Цвет палитры</param>
        public abstract void Paint(Palette color);

        /// <summary>
        /// Преобразование фигуры в Xml для дальнейшего сохраниения через XmlWriter 
        /// </summary>
        /// <param name="xmlWriter">Ссылка на внешний XmlTextWriter </param>
        public abstract void ToXmlWriter(XmlTextWriter xmlWriter);

        /// <summary>
        /// Преобразование фигуры в Xml для дальнейшего сохраниения через StreamWriter 
        /// </summary>
        /// <param name="Document">Ссылка на документ</param>
        /// <returns>Возвращает элемент документа</returns>
        public abstract XmlNode ToStreamWriter(XmlDocument Document);

        /// <summary>
        /// Тип фигуры.
        /// </summary>
        public abstract string Type { get; }

        public override int GetHashCode()
        {
            return HashCode.Combine(Material, Area, Perimeter, Type);
        }

        public override string ToString()
        {
            return String.Format("Тип: {4}, Площадь: {0}, Периметр: {1}, Материал: {2}, Цвет: {3}",
                Area.ToString("f2"), Perimeter.ToString("f2"), Material.ToString(), Material.GetColor().ToString(), Type);
        }

        public override bool Equals(object obj)
        {
            return obj is ShapeBase @base &&
                   EqualityComparer<Material>.Default.Equals(Material, @base.Material) &&
                   Type == @base.Type &&
                   Area.EqualTo(@base.Area, 0.01) &&
                   Perimeter.EqualTo(@base.Perimeter, 0.01);
        }


    }
}
