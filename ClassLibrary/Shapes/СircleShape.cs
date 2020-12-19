using ClassLibrary.Sheets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using static ClassLibrary.ExceptionsClass;

namespace ClassLibrary.Shapes
{
    public class СircleShape : ShapeBase
    {
        double radius;
        private Material material;

        private string type = "СircleShape";
        public override string Type => type;
        public override Material Material => material;

        /// <summary>
        /// Конструктор фигуры из материала
        /// </summary>
        /// <param name="radius">Радиус окружности</param>
        /// <param name="material">Материал для создания новой фигуры</param>
        public СircleShape(double radius, Material material)
        {
            this.radius = radius;
            this.material = material;
        }
        /// <summary>
        /// Конструктор фигуры из другой фигуры
        /// </summary>
        /// <param name="radius">Радиус окружности</param>
        /// <param name="cutting_shape">Фигура для вырезания</param>
        public СircleShape(double radius, ShapeBase cutting_shape)
        {
            this.radius = radius;
            this.material = cutting_shape.Material;

            if (Area < cutting_shape.Area)
            {
                cutting_shape.Cutting(Area);
            }
            else
            {
                throw new ShapeExceptions("Площадь новой фигуры больше основной!");
            }

        }
        /// <summary>
        /// Периметр окружности
        /// </summary>
        public override double Perimeter
        {
            get
            {
                double perimeter = 2 * Math.PI * radius;
                if (double.IsNaN(perimeter))
                {
                    return 0;
                }
                return perimeter;
            }
        }
        /// <summary>
        /// Площадь окружности
        /// </summary>
        public override double Area
        {
            get
            {
                double area = Math.PI * (radius * radius);
                if (double.IsNaN(area))
                {
                    return 0;
                }
                return area;
            }
        }

        /// <summary>
        /// Уменьшить площадь фигуры
        /// </summary>
        /// <param name="area">Площадь</param>
        public override void Cutting(double area)
        {
            double old_area = Area;
            double new_area = old_area - area;
            double koef = (new_area / old_area);
            radius *= koef;
        }

        /// <summary>
        /// Окрасить фигуру
        /// </summary>
        /// <param name="color">Цвет окрашивания</param>
        public override void Paint(Colors.Palette color)
        {
            material.Paint(color);
        }

        /// <summary>
        /// Преобразование фигуры в элемент xml
        /// </summary>
        /// <param name="Document">Ссылка на документ</param>
        /// <returns>Возвращает XmlNode элемент </returns>
        public override XmlNode ToStreamWriter(XmlDocument Document)
        {
            XmlNode shape = Document.CreateElement(Type);
            XmlAttribute attributeRadius = Document.CreateAttribute("Radius");
            attributeRadius.Value = radius.ToString();

            XmlAttribute attributeMaterial = Document.CreateAttribute("Material");
            attributeMaterial.Value = Material.ToString();

            XmlAttribute attributeIsPainted = Document.CreateAttribute("IsPainted");
            attributeIsPainted.Value = Material.IsPainted().ToString();

            XmlAttribute attributeColor = Document.CreateAttribute("Color");
            attributeColor.Value = Material.GetColor().ToString();

            shape.Attributes.Append(attributeRadius);
            shape.Attributes.Append(attributeMaterial);
            shape.Attributes.Append(attributeIsPainted);
            shape.Attributes.Append(attributeColor);
            return shape;
        }
        /// <summary>
        /// Преобразование фигуры в элемент xml
        /// </summary>
        /// <param name="xmlWriter">Ссылка на XmlTextWriter</param>
        public override void ToXmlWriter(XmlTextWriter xmlWriter)
        {

            xmlWriter.WriteStartElement(Type); //Тип фигуры

            xmlWriter.WriteAttributeString("Radius", radius.ToString());
            xmlWriter.WriteAttributeString("Material", Material.ToString());
            xmlWriter.WriteAttributeString("IsPainted", Material.IsPainted().ToString());
            xmlWriter.WriteAttributeString("Color", Material.GetColor().ToString());

            xmlWriter.WriteEndElement();
        }
    }
}
